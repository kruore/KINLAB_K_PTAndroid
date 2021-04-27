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
    Pos01, Pos02, Pos03, Pos04
}

public class GM_PosManager : MonoBehaviour
{
    [Header("Dance Pos")]
    public static GM_PosManager instance = null;
    public Dance dance;
    int CurrenDance = 1;

    public float timer = 0.0f;
    public Text timerText;
    public float waitTimer = 0.0f;
    public Text waitTimerText;

    public GameObject Pos01;
    public GameObject Pos02;
    public GameObject Pos03;
    public GameObject Pos04;

    public Vector3[] HeadPos = new Vector3[4];
    public Vector3[] LeftHandPos = new Vector3[4];
    public Vector3[] RightHandPos = new Vector3[4];
    public Vector3[] RightElbowPos = new Vector3[4];
    public Vector3[] LeftElbowPos = new Vector3[4];

    public GameObject Head;
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject RightElbow;
    public GameObject LeftElbow;

    [Header("Dance Pos Checker")]
    public bool isHead = false;
    public bool isLeftHand = false;
    public bool isRightHand = false;
    public bool isRightElbow = false;
    public bool isLeftElbow = false;

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
            this.transform.position = new Vector3(0f, 0f, -10f);
        }
        else
        {
            Destroy(this.gameObject);
        }
        this.transform.position = new Vector3(0f, 0f, -10f);
    }
    public void Start()
    {
        lineColor = new Image[linecontainer.transform.childCount];
        dance = Dance.Pos04;
        for (int i = 0; i < linecontainer.transform.childCount; i++)
        {
            lineColor[i] = linecontainer.gameObject.transform.GetChild(i).GetComponent<Image>();
        }
        initallizePos();
        timer = 3.0f;
    }
    public void initallizePos()
    {
        //Pos01
        HeadPos[0] = new Vector3(0.0f, 2.4f, 0f);
        LeftHandPos[0] = new Vector3(3.36f, 2.65f, 0f);
        RightHandPos[0] = new Vector3(-3.36f, -1.85f, 0f);
        RightElbowPos[0] = new Vector3(3.36f, 0.4f, 0f);
        LeftElbowPos[0] = new Vector3(-3.36f, 0.4f, 0f);
        //Pos02
        HeadPos[1] = new Vector3(0.0f, 2.4f, 0f);
        LeftHandPos[1] = new Vector3(3.47f, 2.75f, 0f);
        RightHandPos[1] = new Vector3(-3.47f, 2.75f, 0f);
        RightElbowPos[1] = new Vector3(3.47f, 0.52f, 0f);
        LeftElbowPos[1] = new Vector3(-3.47f, 0.52f, 0f);

        //Pos03
        HeadPos[2] = new Vector3(0.0f, 2.4f, 0f);
        LeftHandPos[2] = new Vector3(2.3f, 2.6f, 0f);
        RightHandPos[2] = new Vector3(-2.3f, 2.6f, 0f);
        RightElbowPos[2] = new Vector3(3.36f, 0.4f, 0f);
        LeftElbowPos[2] = new Vector3(-3.36f, 0.4f, 0f);

        //Pos04
        HeadPos[3] = new Vector3(0.0f, 2.4f, 0f);
        LeftHandPos[3] = new Vector3(3.36f, -1.85f, 0f);
        RightHandPos[3] = new Vector3(-3.36f, 2.65f, 0f);
        RightElbowPos[3] = new Vector3(3.36f, 0.4f, 0f);
        LeftElbowPos[3] = new Vector3(-3.36f, 0.4f, 0f);
        dance = Dance.Pos01;
    }
    public void DancsPosActive()
    {
        switch (dance)
        {
            case Dance.Pos01:
                Pos01.SetActive(true);
                Pos02.SetActive(false);
                Pos03.SetActive(false);
                Pos04.SetActive(false);
                Head.transform.localPosition = HeadPos[0];
                LeftHand.transform.localPosition = LeftHandPos[0];
                RightHand.transform.localPosition = RightHandPos[0];
                RightElbow.transform.localPosition = LeftElbowPos[0];
                LeftElbow.transform.localPosition = RightElbowPos[0];
                break;

            case Dance.Pos02:
                Pos01.SetActive(false);
                Pos02.SetActive(true);
                Pos03.SetActive(false);
                Pos04.SetActive(false);
                Head.transform.localPosition = HeadPos[1];
                LeftHand.transform.localPosition = LeftHandPos[1];
                RightHand.transform.localPosition = RightHandPos[1];
                RightElbow.transform.localPosition = LeftElbowPos[1];
                LeftElbow.transform.localPosition = RightElbowPos[1];
                break;

            case Dance.Pos03:
                Pos01.SetActive(false);
                Pos02.SetActive(false);
                Pos03.SetActive(true);
                Pos04.SetActive(false);
                Head.transform.localPosition = HeadPos[2];
                LeftHand.transform.localPosition = LeftHandPos[2];
                RightHand.transform.localPosition = RightHandPos[2];
                RightElbow.transform.localPosition = LeftElbowPos[2];
                LeftElbow.transform.localPosition = RightElbowPos[2];
                break;

            case Dance.Pos04:
                Pos01.SetActive(false);
                Pos02.SetActive(false);
                Pos03.SetActive(false);
                Pos04.SetActive(true);
                Head.transform.localPosition = HeadPos[3];
                LeftHand.transform.localPosition = LeftHandPos[3];
                RightHand.transform.localPosition = RightHandPos[3];
                RightElbow.transform.localPosition = LeftElbowPos[3];
                LeftElbow.transform.localPosition = RightElbowPos[3];
                break;
        }
    }

    public bool AllPlaced()
    {
        if (isLeftHand && isRightHand && isHead && isRightElbow && isLeftElbow)
        {
            isLeftHand = false;
            isRightHand = false;
            isHead = false;
            isRightElbow = false;
            isLeftElbow = false;
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
        DancsPosActive();
        AllPlaced();
        if (IsSetPos == true && waitTimer < 0)
        {
            waitTimer = 2.0f;
            timer = 3.0f;
            score++;
            Debug.Log("Score!!");
            scoreText.text = score.ToString();
            if (dance != Dance.Pos04)
            {
                dance++;
            }
            else
            {
                dance = Dance.Pos01;
            }
        }
        timer -= Time.deltaTime;
        waitTimer -= Time.deltaTime;
        timerText.text = timer.ToString();
        waitTimerText.text = waitTimer.ToString();
        if (timer < 0 && waitTimer <0)
        {
            waitTimer = 2.0f;
            timer = 3.0f;
            if (dance != Dance.Pos04)
            {
                dance++;
            }
            else
            {
                dance = Dance.Pos01;
            }
        }
    }
}
