using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bulletPooling : MonoBehaviour
{
    public static bulletPooling instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 10;

    [SerializeField] private GameObject bullet;

    void Awake()
    {
        if (instance == null)
        {
            instance = this; // store inside the instance var
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPoolObject() // GameObject == the function will return an obj
    {
        for (int i = 0; i < pooledObjects.Count; i++) // .Countyn == a number cannot be compared with entire list
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }
}
