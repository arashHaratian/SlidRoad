using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    private static RoadGenerator _instance;
public static  RoadGenerator Instance
{
    get { return _instance; }
}
public GameObject[] tilePrefabs;
    
//private Transform playerTransform;
private float spawnZ = -20.0f;
private float tileLength = 40.0f;
private int amountTitlesOnScreen = 6;
private float safeZone = 20.0f;
private int lastPrefabIndex = 0;
private List<GameObject> activeTiles;
private GameObject endOfRoad;
//private IsTrigger isTrigger;


    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }

        else
        {
            _instance = this;
                 
        }
        
        activeTiles = new List<GameObject>();
      //  playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
      //  isTrigger = tilePrefabs[0].GetComponentInChildren<IsTrigger>();
        for (int i = 0; i < amountTitlesOnScreen; i++)
        {
            if (i < 1)
            SpawnTile(0);
            else
            SpawnTile();
        }
    }

   


   public void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            endOfRoad = activeTiles[activeTiles.Count - 1].transform.GetChild(10).gameObject;
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
            Vector3 roadTrueY = new Vector3(endOfRoad.transform.position.x, 0 , endOfRoad.transform.position.z);
            go.transform.position = roadTrueY;
        }

        else
        go = Instantiate(tilePrefabs[prefabIndex], Vector3.forward * -20, Quaternion.identity) as GameObject;
        
        //print(activeTiles[activeTiles.Count-1]);
       
//        go.transform.SetParent(transform);
        
//        print(endOfRoad.transform.position);
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }


    
}
