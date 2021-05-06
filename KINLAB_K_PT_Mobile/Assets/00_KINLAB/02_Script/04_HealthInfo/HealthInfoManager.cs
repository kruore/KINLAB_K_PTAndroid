using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;
using System.Globalization;

namespace _KINLAB
{
    public struct HealthInfoData
    {
        public ulong date;
        public Vector3 acc_data;
        public Vector3 gyro_data;
        public float hrm_data;
    }

    public class HealthInfoManager : MonoBehaviour
    {
        public static HealthInfoManager instance = null;

        [SerializeField]
        private TextMeshProUGUI test_Text_health_Info_Data;

        private int minLength = 70;

        private List<HealthInfoData> list_healthInfoData = new List<HealthInfoData>();

        //------------------

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            //Update_Test_Text_health_Info_Data();
        }

        private void Update()
        {
            //Update_Test_Text_health_Info_Data();

            //string ee = "?? 11:56:08 // X: 2.845066 Y: 2.158326 Z: 8.930015 // Heart Rate: 76";
            //string aa = ee.Substring(0, 68);
            //Debug.Log(aa);
            //Debug.Log(ee.Length);
        }

        //public void Update_Test_Text_health_Info_Data()
        //{
        //    if (TCPIP_Socket_Client.instance != null)
        //    {
        //        string temps = TCPIP_Socket_Client.instance.Get_LastData_from_Queue();
        //        //string temps = "";
        //        //string temps = TCPIP_Socket_Client.instance.Temp_serverMessage;
        //        //string temps = TCPIP_Socket_Client.instance.TempQ_serverMessage.Dequeue();
        //        //temps.cu


        //        try
        //        {
        //            test_Text_health_Info_Data.text = string.Empty;
        //            //test_Text_health_Info_Data.text = temps.Substring(0, minLength);

        //            //char[] delimiters = { '|' };
        //            //string[] splitted_string_loaded_Data = temps.Split(delimiters);

        //            //if (splitted_string_loaded_Data.Length >= 2)
        //            //{
        //            //    test_Text_health_Info_Data.text = splitted_string_loaded_Data[1];
        //            //}
        //            //Debug.Log("count : " + count + " /// " + temps);

        //            char[] delimiters = { ';', ',' };
        //            string[] splitted_string_loaded_Data = temps.Split(delimiters[0]);

        //            if (!Check_Long(splitted_string_loaded_Data[0]))
        //                return;




        //            if (splitted_string_loaded_Data.Length >= 2)
        //            {
        //                count++;
        //                test_Text_health_Info_Data.text = splitted_string_loaded_Data[0];
        //                //Debug.Log("count : " + count + " /// " + splitted_string_loaded_Data[0]);


        //                for (int i = 0; i < splitted_string_loaded_Data.Length; i++)
        //                {
        //                    string[] splitted_string_tuple_Data = splitted_string_loaded_Data[i].Split(delimiters[1]);

        //                    HealthInfoData structA = new HealthInfoData();

        //                    try
        //                    {
        //                        ulong templ = 0;
        //                        ulong.TryParse(splitted_string_tuple_Data[0], out templ);
        //                        structA.date = templ;

        //                        //Vector3 tempV = Vector3.zero;
        //                        //float.TryParse(splitted_string_tuple_Data[1], out tempV.x);
        //                        //float.TryParse(splitted_string_tuple_Data[2], out tempV.y);
        //                        //float.TryParse(splitted_string_tuple_Data[3], out tempV.z);
        //                        //structA.acc_data = tempV;

        //                        //tempV = Vector3.zero;
        //                        //float.TryParse(splitted_string_tuple_Data[4], out tempV.x);
        //                        //float.TryParse(splitted_string_tuple_Data[5], out tempV.y);
        //                        //float.TryParse(splitted_string_tuple_Data[6], out tempV.z);
        //                        //structA.gyro_data = tempV;

        //                        //float tempF = 0.0f;
        //                        //float.TryParse(splitted_string_tuple_Data[7], out tempF);
        //                        //structA.hrm_data = tempF;

        //                        Vector3 tempV = Vector3.zero;
        //                        var format = new NumberFormatInfo();
        //                        format.NegativeSign = "-";
        //                        tempV.x = float.Parse(splitted_string_tuple_Data[1], format);
        //                        tempV.y = float.Parse(splitted_string_tuple_Data[2], format);
        //                        tempV.z = float.Parse(splitted_string_tuple_Data[3], format);
        //                        structA.acc_data = tempV;

        //                        tempV = Vector3.zero;
        //                        tempV.x = float.Parse(splitted_string_tuple_Data[4], format);
        //                        tempV.y = float.Parse(splitted_string_tuple_Data[5], format);
        //                        tempV.z = float.Parse(splitted_string_tuple_Data[6], format);
        //                        structA.gyro_data = tempV;

        //                        float tempF = 0.0f;
        //                        tempF = float.Parse(splitted_string_tuple_Data[7], format);
        //                        structA.hrm_data = tempF;

        //                    }
        //                    catch (System.Exception e)
        //                    {
        //                        Debug.Log(e);

        //                        throw;
        //                    }


        //                    list_healthInfoData.Add(structA);
        //                    //GM_DataRecord.instance.Rec(structA);

        //                    //date
        //                    //acc_x
        //                    //acc_y
        //                    //acc_z
        //                    //gyr_x
        //                    //gyr_y
        //                    //gyr_z
        //                    //hr
        //                }
        //            }


        //        }
        //        catch (System.Exception e)
        //        {
        //            Debug.Log(e.ToString());
        //        }


        //    }
            
        //}

        public bool Check_Long(string _data)
        {
            try
            {
                long templ;
                long.TryParse(_data, out templ);

                return true;
            }
            catch (System.Exception e)
            {
                Debug.Log(e);

                return false;
                throw;
            }


        }

        public void Update_Test_Text_health_Info_Data(string _queueData)
        {
            if (TCPIP_Socket_Client.instance != null)
            {
                try
                {
                    test_Text_health_Info_Data.text = string.Empty;

                    char[] delimiters = { ',' };

                    test_Text_health_Info_Data.text = _queueData;

                    string[] splitted_string_tuple_Data = _queueData.Split(delimiters[0]);

                    if (splitted_string_tuple_Data.Length < 8)
                        return;

                    HealthInfoData structA = new HealthInfoData();
                    structA.date = 0;
                    structA.acc_data = Vector3.zero;
                    structA.gyro_data = Vector3.zero;
                    structA.hrm_data = 0.0f;

                    try
                    {
                        ulong templ = 0;
                        ulong.TryParse(splitted_string_tuple_Data[0], out templ);
                        structA.date = templ;

                        //Vector3 tempV = Vector3.zero;
                        //float.TryParse(splitted_string_tuple_Data[1], out tempV.x);
                        //float.TryParse(splitted_string_tuple_Data[2], out tempV.y);
                        //float.TryParse(splitted_string_tuple_Data[3], out tempV.z);
                        //structA.acc_data = tempV;

                        //tempV = Vector3.zero;
                        //float.TryParse(splitted_string_tuple_Data[4], out tempV.x);
                        //float.TryParse(splitted_string_tuple_Data[5], out tempV.y);
                        //float.TryParse(splitted_string_tuple_Data[6], out tempV.z);
                        //structA.gyro_data = tempV;

                        //float tempF = 0.0f;
                        //float.TryParse(splitted_string_tuple_Data[7], out tempF);
                        //structA.hrm_data = tempF;

                        Vector3 tempV = Vector3.zero;
                        var format = new NumberFormatInfo();
                        format.NegativeSign = "-";
                        tempV.x = float.Parse(splitted_string_tuple_Data[1], format);
                        tempV.y = float.Parse(splitted_string_tuple_Data[2], format);
                        tempV.z = float.Parse(splitted_string_tuple_Data[3], format);
                        structA.acc_data = tempV;

                        tempV = Vector3.zero;
                        tempV.x = float.Parse(splitted_string_tuple_Data[4], format);
                        tempV.y = float.Parse(splitted_string_tuple_Data[5], format);
                        tempV.z = float.Parse(splitted_string_tuple_Data[6], format);
                        structA.gyro_data = tempV;

                        float tempF = 0.0f;
                        tempF = float.Parse(splitted_string_tuple_Data[7], format);
                        structA.hrm_data = tempF;

                    }
                    catch (System.Exception e)
                    {
                        Debug.Log(e);
                        //throw;
                    }


                    list_healthInfoData.Add(structA);
                    GM_DataRecord.instance.Rec(structA);


                }
                catch (System.Exception e)
                {
                    Debug.Log(e.ToString());
                    //throw;
                }


            }

        }

    }
}