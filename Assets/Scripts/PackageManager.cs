using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = System.Random;

public class PackageManager: MonoBehaviour
{
    public static PackageManager Instance = null;

    public GameObject greenCube;
    public GameObject redCube;
    public GameObject[] badPackages;
    
    private Transform goodPoint;
    private Transform badPoint;
    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else if(Instance != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    bool FindGoodPoints(Transform tRoad)
    {
        for (int i = 1; i < tRoad.childCount; i++)
        {
            Transform child = tRoad.GetChild(i);
            if (child.CompareTag("GoodPoint"))
            {
                goodPoint = child;
                return true;
            }
            
        }
        return false;
    }
    
    void SpawnGreenCube()
    {
        System.Random random = new System.Random();
        if (random.Next(0, 1) == 0)
        {
            Instantiate(greenCube, goodPoint);
        }
        
    }
    
    bool FindBadPoints(Transform tRoad)
    {
        for (int i = 1; i < tRoad.childCount; i++)
        {
            Transform child = tRoad.GetChild(i);
            if (child.CompareTag("BadPoint"))
            {
                badPoint = child;
                return true;
            }
        }
        return false;
    }

    void SpawnBadObject()
    {
        Random random = new Random();
        if (ScoreManager.combo != 1 && random.Next(0,1) == 0)
        {
            Instantiate(redCube, badPoint);
            return;
        }
        
        int rIndex = random.Next(0, badPackages.Length + 2);
        if (rIndex < badPackages.Length)
            Instantiate(badPackages[rIndex], badPoint);
    }
    public void InsertPackage(GameObject road)
    {
        
        if (FindGoodPoints(road.transform))
            SpawnGreenCube();
    
        if (FindBadPoints(road.transform))
            SpawnBadObject();
    }
}
