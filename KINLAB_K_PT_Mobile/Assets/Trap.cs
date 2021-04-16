using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    public Text text01;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == gameObject.tag)
        {
            if (other.gameObject.CompareTag("Head"))
            {
                GM_DancePosManager.instance.isHead = true;
                Debug.Log("Head");
            }
            if (other.gameObject.CompareTag("RightHand"))
            {
                GM_DancePosManager.instance.isLeftHand = true;
                Debug.Log("Righthand");
            }
            if (other.gameObject.CompareTag("LeftHand"))
            {
                GM_DancePosManager.instance.isRightHand = true;
                Debug.Log("LeftHand");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == gameObject.tag)
        {
            if (other.gameObject.CompareTag("Head"))
            {
                GM_DancePosManager.instance.isHead = false;
                Debug.Log("Head out");
            }
            if (other.gameObject.CompareTag("RightHand"))
            {
                GM_DancePosManager.instance.isLeftHand = false;
                Debug.Log("Righthand out");
            }
            if (other.gameObject.CompareTag("LeftHand"))
            {
                GM_DancePosManager.instance.isRightHand = false;
                Debug.Log("LeftHand out");
            }
        }
    }
}
