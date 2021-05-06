using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _KINLAB {
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject Button_Start;

        [SerializeField]
        private GameObject Button_Stop;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Button_RequestSensorStart()
        {
            Button_Start.SetActive(false);
            Button_Stop.SetActive(true);

            TCPclt_TAP.instance.Button_RequestSensorStart();
        }

        public void Button_RequestSensorStop()
        {
            Button_Stop.SetActive(false);
            Button_Start.SetActive(true);

            TCPclt_TAP.instance.Button_RequestSensorStop();
        }

        public void Button_Request_Analaysis()
        {
            TCPclt_TAP.instance.Button_Request_Analaysis();
        }

    }
}