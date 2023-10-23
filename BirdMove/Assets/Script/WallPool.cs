using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPool : MonoBehaviour
{
    public static WallPool Instance;

    [SerializeField]List<GameObject> poolWalls = new List<GameObject>();

    int wallCount = 3;

    [SerializeField] GameObject wallPrefab = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        for(int i = 0; i < wallCount; i++)
        {
            GameObject obj = Instantiate(wallPrefab);
            obj.SetActive(false);
            poolWalls.Add(obj);
        }

    }


    public GameObject GetPoolOnject()   //off된 것 중에 가장 앞의 것
    {
        for (int i = 0; i < poolWalls.Count; i++)
        {
            if (!poolWalls[i].activeInHierarchy)
            {
                return poolWalls[i];
            }
        }
        return null;
    }


    public void ResetPool()
    {
        for (int i = 0; i < poolWalls.Count; i++)
        {
            poolWalls[i].SetActive(false);
        }
    }

}
