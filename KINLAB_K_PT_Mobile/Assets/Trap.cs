using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update

    public Text text01;
    int a;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand"))
        {
            a++;
            Debug.Log("Point up");
            text01.text =a.ToString();
        }
    }


}
