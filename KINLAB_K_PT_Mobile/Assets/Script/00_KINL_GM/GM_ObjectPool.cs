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
    Queue<TouchUnit> poolingObjectQueue = new Queue<TouchUnit>();
    private void Awake()
    {
        Instance = this;
        Initialize(3);
    }
    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }
    private TouchUnit CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<TouchUnit>();
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
    public static void ReturnObject(TouchUnit obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }

}