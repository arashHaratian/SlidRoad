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
    public List<GameObject> CubeInRoads;

    private List<Transform> goodPoints;
    private List<Transform> badPoints;
    private Road currentRoad;
    public int numOfSkippedGreeenBoxes;
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
        CubeInRoads = new List<GameObject>();
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
            CubeInRoads.Add(Instantiate(greenCube, instantiatePoint));
            return;
        }

        if (chance < probabilityGoodPackage)
        {
            int rIndex = random.Next(0, goodPackage.Length);
            Instantiate(goodPackage[rIndex],instantiatePoint);
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
        
        if (road.GetComponent<Road>())
            currentRoad = road.GetComponent<Road>();
        
        FindBGPoints(road.transform);
        SpawnGoodObject();
        goodPoints.Clear();
        SpawnBadObject();
        badPoints.Clear();
    }
    public void BoxState()
    {
        for (int i=0;i<CubeInRoads.Count;i++)
        {
            if (!CubeInRoads[i])
                CubeInRoads.RemoveAt(i);
            else if (CubeInRoads[i].transform.position.z < 0)
            {
                if (ScoreManager.numberOfTakenGreenboxes > 0)
                {
                    numOfSkippedGreeenBoxes++;
                    BoxesStateText.Instance.UpdateText(numOfSkippedGreeenBoxes.ToString());

                }
                CubeInRoads.RemoveAt(i);
//                Destroy(CubeInRoads[i]);
                break;
            }
        }
        if(numOfSkippedGreeenBoxes > 2)
        {
            ScoreManager.combo = 1;
            BoxesStateText.Instance.FinishBoxesState();
            ScoreManager.numberOfTakenGreenboxes = 0;
            MusicManager.instance.startResetMusicSpeed();
            BackGroundColor.instance.Reset();
        }
    }
    public void restart()
    {
        BoxesStateText.Instance.FinishBoxesState();
        CubeInRoads.Clear();
        numOfSkippedGreeenBoxes = 0;
    }
}
