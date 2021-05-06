using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AI_Result_UI_UpdateCtrl : MonoBehaviour
{
    public static AI_Result_UI_UpdateCtrl instance = null;

    [SerializeField]
    private Text test_Text_health_Info_Data;

    private char[] delimiters = { '\t', '\n' };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Update_AVG_UI(ref string[] _data)
    {
        //[127.0.0.1:4444] [202012071711.999] [Report_AI_Result] [37] [AI] [JSB] [data] 7개
        //0.003   1.069   6.726   0.032   0.141   0.212;
        test_Text_health_Info_Data.text = string.Empty;

        if (_data.Length < 7)
            return;

        string[] aplitted_AVG_Data = _data[6].Split(delimiters);


        /// AVG
        //if (aplitted_AVG_Data.Length < 6)
        //    return;
        ///*
        //Date : 000000000000.000
        //    Account : 000
        //    Acc AVG : (null, null, null)
        //    Gyro AVG : (null, null, null)
        //*/

        //test_Text_health_Info_Data.text = string.Format("Date : {0}\nAccount : {1}\nAcc AVG : ({2}, {3}, {4})\nGyro AVG : ({5}, {6}, {7})",
        //    _data[1],
        //    _data[5],
        //    aplitted_AVG_Data[0],
        //    aplitted_AVG_Data[1],
        //    aplitted_AVG_Data[2],
        //    aplitted_AVG_Data[3],
        //    aplitted_AVG_Data[4],
        //    aplitted_AVG_Data[5]
        //    );

        test_Text_health_Info_Data.text += string.Format("\nDate : {0}\nAccount : {1}\nExercise Time : {2} sec\n", _data[1], _data[5], ((aplitted_AVG_Data.Length - 2) * 2));
        test_Text_health_Info_Data.text += "\n-----------------------------------------------------\n\n";

        int j = 0;

        for (int i = 0; i < aplitted_AVG_Data.Length; i++)
        {
            string[] aplitted_AI_Result_ = aplitted_AVG_Data[i].Split('_'); // 1_0.9545    per 100 samples 

            if (aplitted_AI_Result_.Length < 2)
                continue;

            string text = string.Empty;

            switch (aplitted_AI_Result_[0])
            {
                case "0": //서있기
                    text += (++j).ToString() + "번 구간에서의 운동 자세 : 스탠딩";
                    break;

                case "1": //good squat
                    text += (++j).ToString() + "번 구간에서의 운동 자세 : 올바른 스쿼트";
                    break;

                case "2": //insufficient depth
                    text += (++j).ToString() + "번 구간에서의 운동 자세 : 잘못된 스쿼트";
                    break;

            }

            if(text != string.Empty)
            {
                test_Text_health_Info_Data.text += text + " (확신도" + aplitted_AI_Result_[1] + ")\n";
            }

        }
        
        //test_Text_health_Info_Data.text += string.Format("\nExercise Time : {0} sec\n", ((aplitted_AVG_Data.Length-2) * 2));

    }
}
