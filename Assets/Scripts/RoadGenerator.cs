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
    public GameObject[] easyTilePrefabs;
    public GameObject[] mediumTilePrefabs;
    public GameObject[] hardTilePrefabs;
    public GameObject roadMap;
    public int roadOnScreen = 6;
    public int counts;

    public GameObject CurrentRoad
    {
        get { return activeTiles[1]; }
    }
    private GameObject lastRoad;
    private Vector3 endOfRoad;
    private int firstSpawnCount = 5;
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
        for (int i = 1; i < firstSpawnCount; i++)
        {
            SpawnTile(easyTilePrefabs);
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
            DetectionOfPlayerMovement.num = 0;
        }
        Init();   
    }

    public void SpawnTile(GameObject[] tiles)
    {
        counts++;
        lastRoad = Instantiate(tiles[RandomPrefabIndex(tiles)], lastRoad.transform.GetChild(0).gameObject.transform.position,lastRoad.transform.rotation);
        lastRoad.transform.parent = roadMap.transform;
        activeTiles.Add(lastRoad);
    }

    private void SpawnFirstTile()
    {
        lastRoad = Instantiate(firstTile, Vector3.zero, Quaternion.identity);
        lastRoad.transform.parent = roadMap.transform;
        activeTiles.Add(lastRoad);
        GameOverManager.instance.CalGameOverPosition(lastRoad);
    }

   public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex(GameObject[] tiles)
    {
       if (easyTilePrefabs.Length <= 1)
           return 0;
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tiles.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
