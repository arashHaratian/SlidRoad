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
    public GameObject[] goodPackage;
    
    private List<Transform> goodPoints;
    private List<Transform> badPoints;
    System.Random random = new System.Random();

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else if(Instance != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
        
        goodPoints = new List<Transform>();
        badPoints = new List<Transform>();
    }

    void FindBGPoints(Transform tRoad)
    {
        for (int i = 1; i < tRoad.childCount; i++)
        {
            Transform child = tRoad.GetChild(i);
            if (child.CompareTag("GoodPoint"))
                goodPoints.Add(child);
            else if(child.CompareTag("BadPoint"))
                badPoints.Add(child);
        }
        
    }
    
    void SpawnGoodObject()
    {
        if(goodPoints.Count == 0)
            return;
        Transform instantiatePoint = goodPoints[random.Next(goodPoints.Count)];
        print(instantiatePoint);
        if (random.Next(0, 4) < 3)
        {
            Instantiate(greenCube, instantiatePoint);
            return;
        }
        int rIndex = random.Next(0, goodPackage.Length + 1);
        if (rIndex < goodPackage.Length)
            Instantiate(goodPackage[rIndex],instantiatePoint);
    }
    void SpawnBadObject()
    {
        if (ScoreManager.combo == 1)
            return;
        for(int i = 0; i < badPoints.Count; i++)
        {
            if (random.Next(0,2) < 1)
               Instantiate(redCube, badPoints[i]);
            print("spawn bad things");
        }
    }
    public void InsertPackage(GameObject road)
    {
        FindBGPoints(road.transform);
        SpawnGoodObject();
        goodPoints.Clear();
        SpawnBadObject();
        badPoints.Clear();
    }
}
