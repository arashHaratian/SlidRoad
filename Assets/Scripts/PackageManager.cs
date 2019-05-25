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
    private PackageChance currentRoad;
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
        int probabilityGoodPackage;
        probabilityGoodPackage = currentRoad.probabiltyInsertGoodPackage;
        Transform instantiatePoint = goodPoints[random.Next(goodPoints.Count)];
        int chance = random.Next(0, 100);
        if (chance < probabilityGoodPackage)
        {
            Instantiate(greenCube, instantiatePoint);
        }
   }
    void SpawnBadObject()
    {
        if (ScoreManager.numberOfTakenGreenboxes == 0 || badPoints.Count == 0)
            return;
        int probabilityBadPackage;
        probabilityBadPackage = currentRoad.probabiltyInsertBadPackage;
        int chance = random.Next(0, 100);
        for(int i = 0; i < badPoints.Count; i++)
        {
            if (chance < probabilityBadPackage)
               Instantiate(redCube, badPoints[i]);
        }
    }
    public void InsertPackage(GameObject road)
    {
        if (road.GetComponent<PackageChance>())
            currentRoad = road.GetComponent<PackageChance>();
        
        FindBGPoints(road.transform);
        SpawnGoodObject();
        goodPoints.Clear();
        SpawnBadObject();
        badPoints.Clear();
    }
}
