using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GM_ObjectPool : MonoBehaviour
{
    public static GM_ObjectPool Instance;
    [SerializeField]
    private GameObject poolingObjectPrefab;
    [SerializeField]
    private GameObject poolingScorePrefeb;
    [SerializeField]
    public Queue<TouchUnit> poolingObjectQueue = new Queue<TouchUnit>();
    [SerializeField]
    public Queue<ScorePopPref> poolingObjectScoreQueue = new Queue<ScorePopPref>();
    private void Awake()
    {
        Instance = this;
        Initialize(1);
    }
    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
          //  poolingObjectScoreQueue.Enqueue(CreateNewScoreObject());
        }
    }
    private TouchUnit CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<TouchUnit>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }
    private ScorePopPref CreateNewScoreObject()
    {
        var newObj = Instantiate(poolingScorePrefeb).GetComponent<ScorePopPref>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }
    public static TouchUnit GetObject()
    {
        if (Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;

        }
    }
    public static ScorePopPref GetScoreObject()
    {
        if (Instance.poolingObjectScoreQueue.Count > 0)
        {
            var obj = Instance.poolingObjectScoreQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewScoreObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;

        }
    }
    public static void ReturnObject(TouchUnit obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }
    public static void ReturnScoreObject(ScorePopPref obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectScoreQueue.Enqueue(obj);
    }
}