using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RoadGenerator : MonoBehaviour
{
    private static RoadGenerator _instance;
    public static  RoadGenerator Instance
    {
        get
        {
            return _instance;
        }
    }
    
   
    public GameObject firstTile;
    public GameObject[] step1;
    public GameObject[] step2;
    public GameObject[] step3;
    public GameObject[] step4;
    public GameObject[] step5;
    public GameObject[] step6;
    public GameObject roadMap;
    public int roadOnScreen;
    public int counts;
    public Vector3 firstRoadPosition;
    public int index;
    public GameObject CurrentRoad
    {
        get { return activeTiles[1]; }
    }
    private GameObject lastRoad;
    private Vector3 endOfRoad;
    private int lastPrefabIndex;
    private List<GameObject> activeTiles;
    private Color roadColor ;
 
    public List<GameObject> ActiveTiles
    {
        get { return activeTiles; }
    }
    void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this;
        
        activeTiles = new List<GameObject>();
    }

    private void Init()
    {
        SpawnFirstTile();
        for (int i = 1; i < roadOnScreen - 1; i++)
        {
            SpawnTile(step1);
            index++;
        }
        
     //   roadColor = Random.ColorHSV(Random.value, Random.value);
        //MeshRenderer[] renderer =  activeTiles[0].GetComponentsInChildren<MeshRenderer> ();
       // renderer[0].material.color = roadColor;
    }

    public void Restart()
    {
        if (activeTiles.Count > 0)
        {
            for (int i = 0; i < activeTiles.Count; i++)
            {
                Destroy(activeTiles[i]);
            }
            activeTiles.Clear();
            counts = 0;
            index = 0;
            //DetectionOfPlayerMovement.num = 0;
        }
        Init();   
    }

    public void SpawnTile(GameObject[] tiles)
    {
        counts++;
        lastRoad = Instantiate(tiles[index], lastRoad.transform.GetChild(0).gameObject.transform.position,lastRoad.transform.rotation);
        index++;
        lastRoad.transform.parent = roadMap.transform;
        activeTiles.Add(lastRoad);
    }

    private void SpawnFirstTile()
    {
        lastRoad = Instantiate(firstTile, firstRoadPosition, Quaternion.identity);
        lastRoad.transform.parent = roadMap.transform;
        activeTiles.Add(lastRoad);
        GameOverManager.instance.CalGameOverPosition(lastRoad);
    }

   public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

//    private int PrefabIndex(GameObject[] tiles)
//    {
//        
//       if (step1.Length <= 1)
//           return 0;
//        int randomIndex = lastPrefabIndex;
//        while (randomIndex == lastPrefabIndex)
//        {
//            randomIndex = Random.Range(0, tiles.Length);
//        }
//        lastPrefabIndex = randomIndex;
//        return randomIndex;
//}

}
