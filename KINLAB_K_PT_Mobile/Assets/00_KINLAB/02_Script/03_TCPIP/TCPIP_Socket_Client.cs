using System;
using System.Collections;
using System.Collections.Generic;

using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

using UnityEngine.UI;

namespace _KINLAB
{
    public class TCPIP_Socket_Client : MonoBehaviour
    {
        #region private members 	
        private TcpClient socketConnection;
        private Thread clientReceiveThread;
        #endregion

        private bool tempbool = true;

        public static TCPIP_Socket_Client instance = null;

        [SerializeField]
        private string IntroStr;

        [SerializeField]
        private string epilStr;

        [SerializeField]
        private int portNum = 7777;

        //private string temp_serverMessage = string.Empty;
        //public string Temp_serverMessage { get { return temp_serverMessage; }}



        public Queue<string> queue_serverMessage = new Queue<string>();

        //--------------------------

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        // Use this for initialization 	
        void Start()
        {
            StartCoroutine(CheckConnection());
            ConnectToTcpServer();

            //StartCoroutine(TempCorou());

        }
        // Update is called once per frame
        void Update()
        {
            DecodeServerMsg();
        }
        /// <summary> 	
        /// Setup socket connection. 	
        /// </summary> 	
        private void ConnectToTcpServer()
        {
            try
            {
                clientReceiveThread = new Thread(new ThreadStart(ListenForData));
                clientReceiveThread.IsBackground = true;
                clientReceiveThread.Start();
                //Send_Message("3DCL BRP VR Measuring System Client01 is Connected.");
            }
            catch (Exception e)
            {
                Debug.Log("On client connect exception " + e);
            }
        }
        /// <summary> 	
        /// Runs in background clientReceiveThread; Listens for incomming data. 	
        /// </summary>     
        private void ListenForData()
        {
            try
            {
                //socketConnection = new TcpClient("localhost", 8052);
                //socketConnection = new TcpClient("127.0.0.1", portNum);
                socketConnection = new TcpClient("localhost", portNum);

                //Byte[] bytes = new Byte[1024];
                Byte[] bytes = new Byte[1024];
                while (tempbool)
                {
                    // Get a stream object for reading 				
                    using (NetworkStream stream = socketConnection.GetStream())
                    {
                        int length;
                        // Read incomming stream into byte arrary. 					
                        while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            var incommingData = new byte[length];
                            Array.Copy(bytes, 0, incommingData, 0, length);
                            bytes.Initialize();
                            // Convert byte array to string message. 						
                            //string serverMessage = Encoding.ASCII.GetString(incommingData);
                            string serverMessage = Encoding.UTF8.GetString(incommingData);

                            string[] splitted_Tuple_loaded_Data = serverMessage.Split(';');

                            foreach (string item in splitted_Tuple_loaded_Data)
                            {
                                if (item.Length > 0)
                                    queue_serverMessage.Enqueue(item);
                            }
                        }
                    }
                }
            }
            catch (SocketException socketException)
            {
                Debug.Log("Socket exception: " + socketException);
            }
        }
        /// <summary> 	
        /// Send message to server using socket connection. 	
        /// </summary> 	
        public void Send_Message(string _message)
        {
            if (socketConnection == null)
            {
                return;
            }
            try
            {
                // Get a stream object for writing. 			
                NetworkStream stream = socketConnection.GetStream();
                if (stream.CanWrite)
                {
                    //string clientMessage = "This is a message from one of your clients.";
                    //tring clientMessage = "Sir, 3DCL TCP TEST Client sent this message : Hi.";
                    /// Convert string message to byte array.
                    byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(_message);
                    //byte[] clientMessageAsByteArray = Encoding.UTF8.GetBytes(_message);
                    /// Write byte array to socketConnection stream.
                    stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                    //Debug.Log("Client sent his message - should be received by server");
                }
            }
            catch (SocketException socketException)
            {
                Debug.Log("Socket exception: " + socketException);
            }
        }

        public void Send_Message_Index(string _message, int _index)
        {
            if (socketConnection == null)
            {
                return;
            }
            try
            {
                // Get a stream object for writing. 			
                NetworkStream stream = socketConnection.GetStream();
                if (stream.CanWrite)
                {
                    //string clientMessage = "This is a message from one of your clients.";
                    //tring clientMessage = "Sir, 3DCL TCP TEST Client sent this message : Hi.";

                    string message = string.Empty;

                    //switch (_index)
                    //{
                    //    case 0:
                    //        message = "0" + "," + _message;
                    //        break;


                    //    case 1:
                    //        message = "1" + "," + _message;
                    //        break;
                    //}

                    message = _index.ToString() + "," + _message + ",";

                    // Convert string message to byte array.
                    byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(message);
                    // Write byte array to socketConnection stream.
                    stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                    //Debug.Log("Client sent his message - should be received by server");
                }
            }
            catch (SocketException socketException)
            {
                Debug.Log("Socket exception: " + socketException);
            }
        }

        private void OnDisable()
        {
            //Send_Message("\n# "+ DateTime.Now.ToString("yyyyMMddHHmmss.fff") + epilStr);
            Send_Message_Index("\n# " + DateTime.Now.ToString("yyyyMMddHHmmss.fff") + epilStr, 0);
            Send_Message_Index("\n Init Log Client. ", 6);
            tempbool = false;
            socketConnection.Close();
            clientReceiveThread.Abort();
            StopAllCoroutines();
            Debug.Log("Client is Deactivated");
        }

        IEnumerator CheckConnection()
        {
            while (true)
            {
                if (socketConnection != null)
                {
                    //Send_Message(IntroStr);
                    Send_Message("\n# " + DateTime.Now.ToString("yyyyMMddHHmmss.fff") + IntroStr);
                    //Send_Message_Index("\n# " + DateTime.Now.ToString("yyyyMMddHHmmss.fff") + IntroStr, 0);
                    break;
                }
                yield return new WaitForSeconds(1.0f);
            }

            yield break;
        }

        private void DecodeServerMsg()
        {
            if (queue_serverMessage.Count > 0)
            {
                string rawMsg = queue_serverMessage.Dequeue();

                char[] delimiters = { ',' };

                string[] splitted_string_loaded_Data = rawMsg.Split(delimiters[0]);

                if (splitted_string_loaded_Data.Length < 8)
                    return;


                //date
                //acc_x
                //acc_y
                //acc_z
                //gyr_x
                //gyr_y
                //gyr_z
                //hr

                if (HealthInfoManager.instance != null)
                {
                    HealthInfoManager.instance.Update_Test_Text_health_Info_Data(rawMsg);
                }

            }
        }
    }
}