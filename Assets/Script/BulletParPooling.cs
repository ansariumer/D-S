using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletParPooling : MonoBehaviour
{
    public static BulletParPooling instance;

    private List<GameObject> pooledPar = new List<GameObject>();
    private int amountToPool = 15;

    [SerializeField] private GameObject bulletPar;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPar);
            obj.SetActive(false);
            pooledPar.Add(obj);
        }
    }

    public GameObject GetPoolObject()
    {
        for (int i = 0; i < pooledPar.Count; i++)
        {
            if (!pooledPar[i].activeInHierarchy)
            {
                return pooledPar[i];
            }
        }

        return null;
    }
}
