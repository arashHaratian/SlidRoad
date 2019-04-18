using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject[] tilePrefabs;
    
    public GameObject roadMap;    
    private float tileLength = 40.0f;
    private int amountTitlesOnScreen = 6;
    private int lastPrefabIndex = 0;
    private List<GameObject> activeTiles;
    private GameObject endOfRoad;

    void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
        
        activeTiles = new List<GameObject>();
    }

    private void Init()
    {
        for (int i = 0; i < amountTitlesOnScreen; i++)
        {
            if (i < 1)
                SpawnTile(0);
            else
                SpawnTile();
        }
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
        }
        Init();   
    }

   public void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            endOfRoad = activeTiles[activeTiles.Count - 1].transform.GetChild(0).gameObject;
            go = Instantiate(tilePrefabs[RandomPrefabIndex()], endOfRoad.transform.position,activeTiles[activeTiles.Count - 1].transform.rotation);
        }
        else
            go = Instantiate(tilePrefabs[prefabIndex], new Vector3(0,0,-3), Quaternion.identity) as GameObject;

        go.transform.parent = roadMap.transform;
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
