using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_Touchreaction : MonoBehaviour
{
    [Header("Dance Pos")]
    public static GM_Touchreaction instance = null;

    public bool isTouch = false;

    public int comboCounter;
    public bool isCombo;

    public Text scoreText;

    public Text restTimeText;
    public float restTime;
    public int StopTimer;

    public Vector3 tempPos;


    [Header("photo frame Color")]
    public GameObject linecontainer;
    public Image[] lineColor;

    public int score { get { return _score * 100; } set { _score = value; } }
    public int _score;

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

    // Start is called before the first frame update
    void Start()
    {
        StopTimer = 100;
        restTime = 100.0f;
        lineColor = new Image[linecontainer.transform.childCount];
        for (int i = 0; i < linecontainer.transform.childCount; i++)
        {
            lineColor[i] = linecontainer.gameObject.transform.GetChild(i).GetComponent<Image>();
        }
        NewTargetPosition();
    }
    public void GetScore()
    {
        _score++;
        comboCounter++;
        Debug.Log("Score!!");
        scoreText.text = "Score : " + score.ToString();
        isTouch = false;
    }

    public void NewTargetPosition()
    {
        var target = GM_ObjectPool.GetObject();
        var scoreObject = GM_ObjectPool.GetScoreObject();
        scoreObject.transform.position = tempPos;
        target.gameObject.transform.position = new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-3.0f, 4.0f), -10.5f);
        tempPos = target.transform.position;
        StartCoroutine(ScoreExistTime(scoreObject.gameObject));
    }
    IEnumerator ScoreExistTime(GameObject obj)
    {
        yield return new WaitForSeconds(0.5f);
        GM_ObjectPool.ReturnScoreObject(obj.GetComponent<ScorePopPref>());
    }

    // Update is called once per frame
    void Update()
    {
        restTime -= Time.deltaTime;
        StopTimer = (int)restTime;
        restTimeText.text = "Rest Time : " + StopTimer.ToString();
        if (isTouch)
        {
            NewTargetPosition();
            GetScore();
        }
        if (StopTimer == 0)
        {
            Time.timeScale = 0;
        }
    }
}
