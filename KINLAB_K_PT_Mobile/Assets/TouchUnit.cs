using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchUnit : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightHand"))
        {
            GM_Touchreaction.instance.isTouch = true;
            GM_ObjectPool.ReturnObject(this);
            Debug.Log("Righthand in");
        }
        if (other.gameObject.CompareTag("LeftHand"))
        {
            GM_Touchreaction.instance.isTouch = true;
            GM_ObjectPool.ReturnObject(this);
            Debug.Log("Lefthand in");
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("RightHand"))
        {
            GM_Touchreaction.instance.isTouch = false;
            Debug.Log("Righthand out");
        }
        if (other.gameObject.CompareTag("LeftHand"))
        {
            GM_Touchreaction.instance.isTouch = false;
            Debug.Log("LeftHand out");
        }
    }
}
