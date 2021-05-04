//Made By LEE_SANG_JUN
//2021-04-19
//Free Copy


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TargetPosition
{
    Vector3 pos;
    Vector3 rot;
}

public enum Dance
{
    Rollen00, Rollen01, Rollen02
,
}

public class GM_DancePosManager : MonoBehaviour
{
    [Header("Dance Pos")]
    public static GM_DancePosManager instance = null;
    public Dance dance;
    int CurrenDance = 1;

    public GameObject DancePos00;
    public GameObject DancePos01;
    public GameObject DancePos02;

    public Vector3[] HeadPos;
    public Vector3[] LeftHandPos;
    public Vector3[] RightHandPos;
    public Vector3[] RightPelvisPos;
    public Vector3[] LeftPelvisPos;

    public GameObject Head;
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject RightPelvis;
    public GameObject LeftPelvis;

    [Header("Dance Pos Checker")]
    public bool isHead = false;
    public bool isLeftHand = false;
    public bool isRightHand = false;
    public bool isRightPelvis = false;
    public bool isLeftPelvis = false;

    [Header("photo frame Color")]
    public GameObject linecontainer;
    public Image[] lineColor;

    public bool isSetPos;
    public bool IsSetPos { get; set; }

    [Header("score")]
    public Text scoreText;
    public int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void Start()
    {
        lineColor = new Image[linecontainer.transform.childCount];
        dance = Dance.Rollen00;
        for (int i = 0; i < linecontainer.transform.childCount; i++)
        {
            lineColor[i] = linecontainer.gameObject.transform.GetChild(i).GetComponent<Image>();
        }
    }
    public void initallizePos()
    {
        HeadPos[0] = new Vector3(-0.13f, 0.92f, 0f);
        LeftHandPos[0] = new Vector3(-0.85f, -3.353f, 0f);
        RightHandPos[0] = new Vector3(1.85f, -0.96f, 0f);
        LeftPelvisPos[0] = new Vector3(-1.76f, -1.88f, 0f);
        RightPelvisPos[0] = new Vector3(0.88f, -2.99f, 0f);
    }
    public void DancsPos01Active()
    {

        switch (dance)
        {
            case Dance.Rollen00:
                DancePos00.SetActive(true);
                Head.transform.position = HeadPos[0];
                LeftHand.transform.position = LeftHandPos[0];
                RightHand.transform.position = RightHandPos[0];
                RightPelvis.transform.position = LeftPelvisPos[0];
                LeftPelvis.transform.position = RightPelvisPos[0];
                break;
        }

    }

    public bool AllPlaced()
    {
        if (isLeftHand && isRightHand && isHead)
        {
            isLeftHand = false;
            isRightHand = false;
            isHead = false;
            IsSetPos = true;
            return IsSetPos = true;
        }
        else
        {
            return IsSetPos = false;
        }
    }

    public void Update()
    {
        AllPlaced();
        if (IsSetPos == true)
        {
            score++;
            Debug.Log("Score!!");
            scoreText.text = score.ToString() ;
        }

    }
}
