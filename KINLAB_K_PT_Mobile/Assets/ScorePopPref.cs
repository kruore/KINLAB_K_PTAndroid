using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePopPref : MonoBehaviour
{
    [SerializeField]public GameObject targetPref;
    [SerializeField]private Transform scorePopPrefPos;

    // Start is called before the first frame update
    void Start()
    {
     //   targetPref = GM_Touchreaction.instance.transform.GetChild(0).gameObject;
       // this.transform.SetParent(targetPref.transform);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void SetScorePopPostion()
    {
        StartCoroutine(DamageSetup());
    }

    IEnumerator DamageSetup()
    {
        for (int i = 0 ;i<3;i++)
        {
            Debug.Log("µ¿ÀÛ");
            this.gameObject.transform.position = Vector3.zero;
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.SetActive(false);
    }
}
