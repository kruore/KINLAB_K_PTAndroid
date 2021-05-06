using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

using System.Text;
using UnityEngine.SceneManagement;
using TMPro;

namespace _KINLAB
{
    [HideInInspector]
    public enum SensorData_Type { acceleration, angularVelocity, magneticField };

    public class GM_DataRecord : MonoBehaviour
    {

        public static GM_DataRecord instance = null;

        private string rootpath = string.Empty;
        private string folder_Path = string.Empty;

        private string folderName = "KINLAB_DataLog";
        private string fileName = string.Empty;

        private string str_DataCategory = string.Empty;

        [HideInInspector]
        public enum Experiment_Type { EX_K_PT_01 };

        [SerializeField]
        private Experiment_Type curren_EX_Type;
        public Experiment_Type Curren_EX_Type { get { return curren_EX_Type; } }

        private float startTime = 0.0f;
        private float currentTime = 0.0f;

        [HideInInspector]
        public enum Warning_Type
        {
            Ex_Start,
            Ex_End,
            Action_Start,
            Action_Finish,
        }

        [HideInInspector]
        public Queue<string> Queue_EX_DATA;
        [HideInInspector]

        private bool isCategoryPrinted;


        [SerializeField]
        private TextMeshProUGUI text_SavedFiles;

        private int count_SavedFiles = 0;

        private bool bSaved = false;

        [SerializeField]
        private TextMeshProUGUI text_SavedPercent;

        [SerializeField]
        private TextMeshProUGUI text_EventLog;
        //-------------------------------

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }

            //MakeFolder();

            //SetFileName();
            //string curFile = Application.persistentDataPath + "/K_PT_SprotsData/" + fileName + ".txt";
            //if (File.Exists(curFile))
            //    Debug.LogError("File.Exists(curFile)");
        }

        private void Start()
        {
            Queue_EX_DATA = new Queue<string>();
            //Queue_ex_02 = new Queue<string>();
            //Queue_ex_03 = new Queue<string>();
            //Queue_ex_04 = new Queue<string>();


            startTime = currentTime = Time.time;

            GM_DataRecord.instance.Write_Warning(GM_DataRecord.Warning_Type.Ex_Start, "");
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }


        private void Update()
        {

        }

        public void Button_SaveDataFile()
        {
            Write_Warning(Warning_Type.Ex_End, "");

            if (WriteSteamingData_Batch(ref Queue_EX_DATA))
            {
                text_SavedFiles.text = "Saved File : " + (++count_SavedFiles);
            }
            else
            {
                text_SavedFiles.text = "No Saved File...";
            }
        }

        private void MakeFolder()
        {
            


            rootpath = Directory.GetCurrentDirectory();

            folder_Path = System.IO.Path.Combine(rootpath, folderName);

            Directory.CreateDirectory(folder_Path);
        }

        private void SetFileName()
        {
            string fileNameFormat = string.Empty;

            switch (curren_EX_Type)
            {
                case Experiment_Type.EX_K_PT_01:
                    if(PersonalInfo.instance != null)
                    {
                        fileName = PersonalInfo.instance.UserName + "_" + PersonalInfo.instance.UserInternalID + "SprotsData_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    }
                    else
                    {
                        fileName = "SprotsData_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    }
                    break;
            }
        }

        public void Enequeue_Data(string _data)
        {
            currentTime = Time.time;
            string stringRelativeTime = string.Format("{0:F4}", currentTime - startTime);

            string refined_Data = DateTime.Now.ToString("yyyyMMddHHmmss.fff") + "," + stringRelativeTime + "," + _data;

            Queue_EX_DATA.Enqueue(refined_Data);
        }

        public void Save_SteamingData_Batch()
        {
            SceneManager.LoadScene("04 KINL Software Terminated");
            WriteSteamingData_Batch(ref Queue_EX_DATA);
        }

        public bool WriteSteamingData_Batch(ref Queue<string> _Queue_ex)
        {
            if (bSaved)
            {
                return false;
            }

            bSaved = true;

            bool tempb = false;

            try
            {


                //string tempFileName = fileName + ".txt";
                //string file_Location = System.IO.Path.Combine(folder_Path, tempFileName);

                SetFileName();


                string m_str_DataCategory = string.Empty;

                int totalCountoftheQueue = _Queue_ex.Count;

                string catestr = string.Empty;

                Debug.Log("Saving Data Starts. Queue Count : " + totalCountoftheQueue);

                //using (StreamWriter streamWriter = File.AppendText(Application.persistentDataPath + "/" + fileName + ".txt"))
                using (StreamWriter streamWriter = new StreamWriter(Application.persistentDataPath + "/" + fileName + ".txt"))
                {
                    while (_Queue_ex.Count != 0)
                    {
                        for (int i = 0; i < totalCountoftheQueue; i++)
                        {
                            string stringData = _Queue_ex.Dequeue();

                            if (stringData.Length > 0)
                            {
                                if (!isCategoryPrinted)
                                {
                                    switch (curren_EX_Type)
                                    {
                                        case Experiment_Type.EX_K_PT_01:
                                            str_DataCategory = "Unity_Date,Unity_Timestamp,"
                                                + "EventLog,"
                                                + "Sensor_Date,"
                                                + "SmartWatch_ACC_x_axis(g),SmartWatch_ACC_y_axis(g),SmartWatch_ACC_z_axis(g),"
                                                + "SmartWatch_AV_x_axis(deg/sec),SmartWatch_AV_y_axis(deg/sec),SmartWatch_AV_z_axis(deg/sec),"
                                                + "SmartWatch_HRM,"
                                                + "Total Entry Count," + totalCountoftheQueue;
                                            break;
                                    }
                                    streamWriter.WriteLine(str_DataCategory);
                                    isCategoryPrinted = true;
                                }

                                streamWriter.WriteLine(stringData);
                            }
                        }
                    }
                }

                Debug.Log("AAa");


                tempb = true;

                //StartCoroutine(CheckSavingDataCompleted());
            }
            catch (Exception e)
            {
                Debug.Log("WriteSteamingData_BatchProcessing ERROR : " + e);
                //TCPTestClient.instance.Send_Message_Index("\n" + "WriteSteamingData_BatchProcessing ERROR : " + e, 0);
            }

            return tempb;
        }


        public void Write_Warning(Warning_Type _warning, string _additionalMessage)
        {
            string warning_Message = string.Empty;

            switch (_warning)
            {
                case Warning_Type.Ex_Start:
                    warning_Message = "[The Experiment Main Process Starts Now.]";
                    break;

                case Warning_Type.Ex_End:
                    warning_Message = "[The Experiment Main Process Ends Now.]";
                    break;

                case Warning_Type.Action_Start:
                    warning_Message = "[Start Action Now.]";
                    break;

                case Warning_Type.Action_Finish:
                    warning_Message = "[Finish Action Now.]";
                    break;


            }

            Debug.Log(warning_Message);

            text_EventLog.text = warning_Message;
            //TCPTestClient.instance.Send_Message_Index("\n" + DateTime.Now.ToString("yyyyMMddHHmmss.fff") + " : " + warning_Message + " (" + _additionalMessage + ")", 0);
            Enequeue_Data(warning_Message);
        }

        //private IEnumerator CheckSavingDataCompleted()
        //{

        //    if (curren_EX_Type == Experiment_Type.CNES_04)
        //    {
        //        _KINLAB_IMU.IMU_Management.instance.Disconnect_IMU_Sensors();

        //    }


        //    yield return new WaitForSeconds(3.0f);

        //    TempDF.instance.Func01();
        //    TCPTestClient.instance.Send_Message_Index("\n" + DateTime.Now.ToString("yyyyMMddHHmmss.fff") + " : " + "All the data are saved.)", 0);

        //    yield break;
        //}


        public void Rec(HealthInfoData _structData)
        {
            if (bSaved)
                return;

            StringBuilder sb = new StringBuilder();

            sb.Append(',');
            sb.Append(_structData.date.ToString()).Append(',');

            sb.AppendFormat("{0:F4}", _structData.acc_data.x).Append(',');
            sb.AppendFormat("{0:F4}", _structData.acc_data.y).Append(',');
            sb.AppendFormat("{0:F4}", _structData.acc_data.z).Append(',');

            sb.AppendFormat("{0:F4}", _structData.gyro_data.x).Append(',');
            sb.AppendFormat("{0:F4}", _structData.gyro_data.y).Append(',');
            sb.AppendFormat("{0:F4}", _structData.gyro_data.z).Append(',');

            sb.AppendFormat("{0:F4}", _structData.hrm_data);

            if (sb.Length > 0 && sb[sb.Length - 1] == ',')
            {
                sb.Remove(sb.Length - 1, 1);
            }

            Enequeue_Data(sb.ToString());
        }

        public void Button_ActionStart()
        {
            Write_Warning(Warning_Type.Action_Start, "");
        }

        public void Button_ActionFinish()
        {
            Write_Warning(Warning_Type.Action_Finish, "");
        }

    }
}