//Made By LEE_SANG_JUN
//2021-04-19
//Free Copy


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public float playTimer = 0.0f;
    public Text playTimerText;

    public int comboCounter;
    public bool isCombo;

    public bool isBunningTime;
    public Text burnning;

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
    public int score { get { return _score * 100; } set { _score = value;} }
    public int _score;

    public Color collectColor =new Color(0, 1, 0, 0.7f);
    public Color failColor = new Color(1, 0, 0, 0.7f);
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
        playTimer = 100.0f;
        isCombo = false;
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
            isCombo = true;
            return IsSetPos = true;
        }
        else
        {
            return IsSetPos = false;
        }
    }

    public Dance RandomPos()
    {
        int CurrntPos = dance.GetHashCode();
        int RandomDancePos = Random.Range(0, 4);
        Debug.Log(RandomDancePos.ToString());

        while(RandomDancePos == CurrntPos)
        {
            RandomDancePos = Random.Range(0,4);
            Debug.Log("SameNumber");
        }
        switch(RandomDancePos)
        {
            case 0: dance = Dance.Pos01;
                break;
            case 1:
                dance = Dance.Pos02;
                break;
            case 2:
                dance = Dance.Pos03;
                break;
            case 3:
                dance = Dance.Pos04;
                break;
        }
        return dance;   
    }

    public void GetScore()
    {
        _score++;
        comboCounter++;
        Debug.Log("Score!!");
        scoreText.text = "Score : " + score.ToString();
    }

    public void Update()
    {
        DancsPosActive();
        AllPlaced();
        if(IsSetPos)
        {
            Pos01.GetComponent<SpriteRenderer>().color = collectColor;
            
            Pos02.GetComponent<SpriteRenderer>().color = collectColor;
            Pos03.GetComponent<SpriteRenderer>().color = collectColor;
            Pos04.GetComponent<SpriteRenderer>().color = collectColor;
        }
        else
        {
            Pos01.GetComponent<SpriteRenderer>().color = failColor;
            Pos02.GetComponent<SpriteRenderer>().color = failColor;
            Pos03.GetComponent<SpriteRenderer>().color = failColor;
            Pos04.GetComponent<SpriteRenderer>().color = failColor;
        }
        if (IsSetPos == true && waitTimer < 0 && !isBunningTime)
        {
            waitTimer = 2.0f;
            timer = 3.0f;
            GetScore();

            //if Combo.equal(3)
            if (comboCounter == 3)
            {
                isBunningTime = true;
                burnning.gameObject.SetActive(true);
                waitTimer = 1.0f;
                timer = 1.0f;
            }
            RandomPos();
        }
        else if (IsSetPos == true && waitTimer < 0 && isBunningTime)
        {
            waitTimer = 1.0f;
            timer = 1.0f;
            GetScore();
            RandomPos();
        }
        // Didn't get Score
        if (IsSetPos == false && waitTimer < 0)
        {
            waitTimer = 2.0f;
            timer = 3.0f;
            RandomPos();
            isCombo = false;
            comboCounter = 0;
            isBunningTime = false;
            burnning.gameObject.SetActive(false);
        }
        timer -= Time.deltaTime;
        waitTimer -= Time.deltaTime;
        playTimer -= Time.deltaTime;
        if (playTimer < 0)
        {
            Time.timeScale = 0.0f;
        }
        //timerText.text = timer.ToString();
        waitTimerText.text = waitTimer.ToString();
        playTimerText.text = playTimer.ToString();
    }
}