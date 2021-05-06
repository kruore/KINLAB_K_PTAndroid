using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _KINLAB
{
    public class AppQuitCtrl : MonoBehaviour
    {
        //--------------------------------

        public void PressButton_Panel01_1()
        {
            Debug.Log("Application.Quit()");
            Application.Quit();
        }

        public void PressButton_Panel01_2()
        {
            Debug.Log("Destroy(gameObject)");
            Destroy(gameObject);
        }
    }
}
