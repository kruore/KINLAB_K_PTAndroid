using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _KINLAB
{
    public class AppQuitCanvasCtrl : MonoBehaviour
    {
        [SerializeField]
        private GameObject AppQuit_Pref;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Instantiate(AppQuit_Pref);
                //Application.Quit();
            }
        }


        public void Button_AppQuit()
        {
            Instantiate(AppQuit_Pref);
        }
    }
}