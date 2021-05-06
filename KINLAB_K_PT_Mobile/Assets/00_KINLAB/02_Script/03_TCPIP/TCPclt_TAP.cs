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
    public enum Enum_IPC_Message
    {
        Connect = 1,
        Disconnect = 2,

        Request_Sensor_Start = 11,
        Command_Sensor_Start = 12,

        Start_Logging = 21,
        Transfer_one_Sample_Data = 22,

        Request_Sensor_Stop = 31,
        Command_Sensor_Stop = 32,


        Request_Analysis = 34,
        Notify_Data_to_AI_Srv = 35,
        Notify_DataStream_End = 36,
        Report_AI_Result = 37,
        Notify_AI_Result_to_clt = 38




        //Request_Manual_csv_Upload = 41,
        //Command_Manual_csv_Upload = 42,

        //Transfer_csv_file = 51,
        //Receive_csv_file = 52
    }

    public class TCPclt_TAP : MonoBehaviour
    {
        #region private members 	
        private TcpClient socketConnection;
        private Thread clientReceiveThread;
        #endregion

        private bool tempbool = true;

        public static TCPclt_TAP instance = null;

        [SerializeField]
        private string IntroStr;

        [SerializeField]
        private string epilStr;

        //private int portNum = 1031;
        //private int portNum = 4519;
        private int portNum = 4545;
        private string ipAddress = "147.46.4.59"; //SNU ICS 404-2
        //private string ipAddress = "210.94.216.195"; // KINLAB 106

        private Queue<string> queue_SrvMsg = new Queue<string>();

        [SerializeField]
        private Text text_MsgDP;

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
            ConnectToTcpServer();
            StartCoroutine(CheckConnection());
        }
        // Update is called once per frame
        void Update()
        {
            if (queue_SrvMsg.Count > 0)
            {
                DecodeServerMsg();
            }

            if (Input.GetKeyDown(KeyCode.F1))
            {
                Debug.Log("Input.GetKeyDown(KeyCode.F1)");
                Button_RequestSensorStart();
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                Debug.Log("Input.GetKeyDown(KeyCode.F2)");
                Button_RequestSensorStop();
            }

            if (Input.GetKeyDown(KeyCode.F3))
            {
                Debug.Log("Input.GetKeyDown(KeyCode.F2)");
                Button_Request_Analaysis();
            }
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
                socketConnection = new TcpClient(ipAddress, portNum);
                //socketConnection = new TcpClient("192.168.0.16", portNum);
                //socketConnection = new TcpClient("192.168.0.37", portNum);

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
                            // Convert byte array to string message. 						
                            string serverMessage = Encoding.ASCII.GetString(incommingData);
                            Debug.Log("server said" + serverMessage);

                            //string[] splitted_Tuple_loaded_Data = serverMessage.Split(';');

                            //foreach (string item in splitted_Tuple_loaded_Data)
                            //{
                            //    if (item.Length > 0)
                            //        queue_SrvMsg.Enqueue(socketConnection.Client.RemoteEndPoint.ToString() + "," + item);
                            //}

                            queue_SrvMsg.Enqueue(ipAddress + ":" + portNum.ToString() + "," + serverMessage);
                        }
                    }
                }
            }
            catch (SocketException socketException)
            {
                Debug.Log("Socket exception: " + socketException);
            }
        }
        ///// <summary> 	
        ///// Send message to server using socket connection. 	
        ///// </summary> 	
        //public void Send_Message(string _message)
        //{
        //    if (socketConnection == null)
        //    {
        //        return;
        //    }
        //    try
        //    {
        //        // Get a stream object for writing. 			
        //        NetworkStream stream = socketConnection.GetStream();
        //        if (stream.CanWrite)
        //        {
        //            //string clientMessage = "This is a message from one of your clients.";
        //            //tring clientMessage = "Sir, 3DCL TCP TEST Client sent this message : Hi.";
        //            // Convert string message to byte array.
        //            byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(_message);
        //            // Write byte array to socketConnection stream.
        //            stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
        //            //Debug.Log("Client sent his message - should be received by server");
        //        }
        //    }
        //    catch (SocketException socketException)
        //    {
        //        Debug.Log("Socket exception: " + socketException);
        //    }
        //}

        private void Send_Message_Index(string _message, int _index)
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

                    //if (_index == 1 || _index == 2)
                    //{
                    //    message = _message + "," + _index.ToString() + ",SP,JSB,";
                    //}
                    //else
                    //{
                    //    message = _message + "," + _index.ToString() + ",";
                    //}

                    message = _message + "," + _index.ToString() + ",SP,JSB;";

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
            Send_Message_to_srv(Enum_IPC_Message.Disconnect);
            tempbool = false;
            socketConnection.Close();
            clientReceiveThread.Abort();
            Debug.Log("Client is Deactivated");
        }

        IEnumerator CheckConnection()
        {
            while (true)
            {
                if (socketConnection != null)
                {
                    Send_Message_to_srv(Enum_IPC_Message.Connect);
                    break;
                }
                yield return new WaitForSeconds(1.0f);
            }

            yield break;
        }

        public void Send_Message_to_srv(Enum_IPC_Message _IPC_Message)
        {
            string msg = DateTime.Now.ToString("yyyyMMddHHmmss.fff") + "," + _IPC_Message.ToString();
            int msgIndex = (int)_IPC_Message;

            Send_Message_Index(msg, msgIndex);
        }

        public void Button_RequestSensorStart()
        {
            Send_Message_to_srv(Enum_IPC_Message.Request_Sensor_Start);
        }

        public void Button_RequestSensorStop()
        {
            Send_Message_to_srv(Enum_IPC_Message.Request_Sensor_Stop);
        }

        public void Button_Request_Analaysis()
        {
            Send_Message_to_srv(Enum_IPC_Message.Request_Analysis);
        }

        private void DecodeServerMsg()
        {
            ///ex [127.0.0.1:4444] [202012071711.999] [Report_AI_Result] [37] [AI] [JSB] [data] 6ea

            if (queue_SrvMsg.Count > 0)
            {
                string rawMsg = queue_SrvMsg.Dequeue();

                char[] delimiters = { ';', ',' };

                Debug.Log("*** " + rawMsg);

                string[] splitted_string_loaded_Data = rawMsg.Split(delimiters[1]);

                if (splitted_string_loaded_Data.Length < 6)
                    return;

                if (!Check_Int(splitted_string_loaded_Data[3]))
                {
                    Debug.LogError("Check_Int : " + splitted_string_loaded_Data[3]);
                    return;
                }

                int msgIndex = 0;
                int.TryParse(splitted_string_loaded_Data[3], out msgIndex);

                switch (msgIndex)
                {
                    case 38:
                        //Debug.Log(splitted_string_loaded_Data[1] + " " + splitted_string_loaded_Data[2] + " " + splitted_string_loaded_Data[6]);
                        AI_Result_UI_UpdateCtrl.instance.Update_AVG_UI(ref splitted_string_loaded_Data);
                        break;
                }
            }
        }

        public bool Check_Int(string _data)
        {
            try
            {
                int templ;
                int.TryParse(_data, out templ);

                return true;
            }
            catch (System.Exception e)
            {
                Debug.LogError("Check_Int Error : " + _data);

                return false;
                throw;
            }
        }

    }
}