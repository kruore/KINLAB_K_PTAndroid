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
        restTime = 100.0f;
        lineColor = new Image[linecontainer.transform.childCount];
        for (int i = 0; i < linecontainer.transform.childCount; i++)
        {
            lineColor[i] = linecontainer.gameObject.transform.GetChild(i).GetComponent<Image>();
        }
        GM_ObjectPool.Instance.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void GetScore()
    {
        _score++;
        comboCounter++;
        Debug.Log("Score!!");
        scoreText.text = "Score : " + score.ToString();
        isTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        restTime -= Time.deltaTime;
        restTimeText.text = restTime.ToString();
        if (isTouch)
        {
            GetScore();
            GM_ObjectPool.Instance.transform.GetChild(0).gameObject.SetActive(true);
            GM_ObjectPool.Instance.transform.GetChild(0).transform.position= new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-3.0f, 4.0f),-10.5f);
        }
    }
}
