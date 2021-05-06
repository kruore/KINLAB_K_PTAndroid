using System;
using System.Collections;
using System.Collections.Generic;

using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class TCPIP_Socket_Server : MonoBehaviour
{
    #region private members 	
    /// <summary> 	
    /// TCPListener to listen for incomming TCP connection 	
    /// requests. 	
    /// </summary> 	
    private TcpListener tcpListener;
    /// <summary> 
    /// Background thread for TcpServer workload. 	
    /// </summary> 	
    private Thread tcpListenerThread;
    /// <summary> 	
    /// Create handle to connected tcp client. 	
    /// </summary> 	
    private TcpClient connectedTcpClient;
    #endregion

    public static TCPIP_Socket_Server instance = null;

    private bool tempbool = true;

    [SerializeField]
    private int portNum = 1025;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start()
    {
        // Start TcpServer background thread 		
        tcpListenerThread = new Thread(new ThreadStart(ListenForIncommingRequests));
        tcpListenerThread.IsBackground = true;
        tcpListenerThread.Start();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F1))
        //{
        //    SendMessage();
        //}
    }

    /// <summary> 	
    /// Runs in background TcpServerThread; Handles incomming TcpClient requests 	
    /// </summary> 	
    private void ListenForIncommingRequests()
    {
        try
        {
            // Create listener on localhost port 8052. 			
            tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), portNum);
            tcpListener.Start();
            Debug.Log("Server is listening");
            Byte[] bytes = new Byte[1024];
            while (tempbool)
            {
                using (connectedTcpClient = tcpListener.AcceptTcpClient())
                {
                    // Get a stream object for reading 					
                    using (NetworkStream stream = connectedTcpClient.GetStream())
                    {
                        int length;
                        // Read incomming stream into byte arrary. 						
                        while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            var incommingData = new byte[length];
                            Array.Copy(bytes, 0, incommingData, 0, length);
                            // Convert byte array to string message. 							
                            string clientMessage = Encoding.ASCII.GetString(incommingData);
                            Debug.Log("[KINLAB Data TEST Server] " + clientMessage);



                            //Application.Quit();
                            

                            //char[] delimiters = { ',' };
                            //string[] splitted_clientMessage = clientMessage.Split(delimiters);

                            //if (splitted_clientMessage.Length >= 2)
                            //{
                            //    Debug.Log(splitted_clientMessage[0] + splitted_clientMessage[1]);
                            //    if (splitted_clientMessage[0] == "0")
                            //    {
                            //        textObj.text += "\n" + splitted_clientMessage[1];
                            //    }
                            //    else if (splitted_clientMessage[0] == "1")
                            //    {
                            //        trial_text.text = "\n" + splitted_clientMessage[1];
                            //    }
                            //    else if (splitted_clientMessage[0] == "2")
                            //    {
                            //        value_text.text = "\n" + splitted_clientMessage[1];
                            //    }
                            //    else if (splitted_clientMessage[0] == "3")
                            //    {
                            //        textObj.text = string.Empty;
                            //        textObj.text += "\n [LogClient - the Text Window is initialized.]";
                            //        //trial_text.text = string.Empty;
                            //        //value_text.text = string.Empty;

                            //    }
                            //    else if (splitted_clientMessage[0] == "4")
                            //    {
                            //        textObj.text += "\n[LogClient - the Trial Count is initialized.]";
                            //        trial_text.text = "Trial Count : 0";

                            //    }
                            //    else if (splitted_clientMessage[0] == "5")
                            //    {
                            //        textObj.text += "\n[LogClient - the value is initialized]";
                            //        value_text.text = string.Empty;

                            //    }
                            //    else if (splitted_clientMessage[0] == "6")
                            //    {
                            //        textObj.text = string.Empty;
                            //        textObj.text += "\n[LogClient - the LogClinet is initialized all.]";
                            //        value_text.text = string.Empty;
                            //        trial_text.text = string.Empty;

                            //    }

                            //}

                        }
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("SocketException " + socketException.ToString());
        }
    }
    /// <summary> 	
    /// Send message to client using socket connection. 	
    /// </summary> 	
    public void Send_Message(string _message)
    {
        if (connectedTcpClient == null)
        {
            return;
        }

        try
        {
            // Get a stream object for writing. 			
            NetworkStream stream = connectedTcpClient.GetStream();
            if (stream.CanWrite)
            {
                //string serverMessage = "This is a message from your server.";
                //string serverMessage = "Sir, 3DCL TCP TEST Server sent this message : Hello.";
                // Convert string message to byte array.                 
                byte[] serverMessageAsByteArray = Encoding.ASCII.GetBytes(_message);
                // Write byte array to socketConnection stream.               
                stream.Write(serverMessageAsByteArray, 0, serverMessageAsByteArray.Length);
                //Debug.Log("Server sent his message - should be received by client");
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    private void OnDisable()
    {
        tempbool = false;
        tcpListener.Stop();
        connectedTcpClient.Close();
        //tcpListenerThread.Abort();
        Debug.Log("Server is Deactivated");
    }

    private void OnApplicationQuit()
    {

    }

    //private void TCPIP_RawSocket_Test()
    //{
    //    byte[] buffer;
    //    Socket sck;

    //    sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    //    sck.Bind(new IPEndPoint(IPAddress.Any, 7777));
    //    sck.Listen(100);

    //    Socket accpetedSck = sck.Accept();

    //    buffer = new byte[1024];
    //    int bytesRead = accpetedSck.Receive(buffer);
    //    byte[] formatted = new byte[bytesRead];

    //    for (int i = 0; i < bytesRead; i++)
    //    {
    //        formatted[i] = buffer[i];
    //    }

    //    string strData = Encoding.ASCII.GetString(formatted);

    //    if (_KINLAB.HealthInfoManager.instance != null)
    //    {
    //        _KINLAB.HealthInfoManager.instance.Update_Test_Text_health_Info_Data(strData);
    //    }
    //}
}