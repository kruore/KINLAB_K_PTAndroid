using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    public Text text01;

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == gameObject.tag)
        {
            if (other.gameObject.CompareTag("Head"))
            {
                GM_PosManager.instance.isHead = true;
            }
            if (other.gameObject.CompareTag("RightHand"))
            {
                GM_PosManager.instance.isLeftHand = true;
            }
            if (other.gameObject.CompareTag("LeftHand"))
            {
                GM_PosManager.instance.isRightHand = true;
            }
            if (other.gameObject.CompareTag("LeftElbow"))
            {
                GM_PosManager.instance.isLeftElbow = true;
            }
            if (other.gameObject.CompareTag("RightElbow"))
            {
                GM_PosManager.instance.isRightElbow = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == gameObject.tag)
        {
            if (other.gameObject.CompareTag("Head"))
            {
                GM_PosManager.instance.isHead = false;
                //Debug.Log("Head out");
            }
            if (other.gameObject.CompareTag("RightHand"))
            {
                GM_PosManager.instance.isLeftHand = false;
                //Debug.Log("Righthand out");
            }
            if (other.gameObject.CompareTag("LeftHand"))
            {
                GM_PosManager.instance.isRightHand = false;
                //Debug.Log("LeftHand out");
            }
            if (other.gameObject.CompareTag("LeftElbow"))
            {
                GM_PosManager.instance.isLeftElbow = false;
                //Debug.Log("LeftElbow");
            }
            if (other.gameObject.CompareTag("RightElbow"))
            {
                GM_PosManager.instance.isRightElbow = false;
                //Debug.Log("RightElbow");
            }
        }
    }
}
