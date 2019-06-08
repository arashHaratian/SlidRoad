﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Serialization;

public class DetectionOfPlayerMovement : MonoBehaviour
{  
    public static int num ;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (RoadGenerator.Instance.startGame)
            {
                if (RoadGenerator.Instance.counts <= 8)
                {
                    if (RoadGenerator.Instance.counts <= 4)
                        RoadGenerator.Instance.SpawnTile(RoadGenerator.Instance.easyTilePrefabs);
                    else
                        RoadGenerator.Instance.SpawnTile(RoadGenerator.Instance.mediumTilePrefabs);
                }
                else
                {

                    if (RoadGenerator.Instance.counts <= 30)
                    {

                        if (num <= 1)
                            RoadGenerator.Instance.SpawnTile(RoadGenerator.Instance.hardTilePrefabs);

                        else if (num == 2)
                            RoadGenerator.Instance.SpawnTile(RoadGenerator.Instance.easyTilePrefabs);

                        else if (num == 3 || num == 4)
                            RoadGenerator.Instance.SpawnTile(RoadGenerator.Instance.mediumTilePrefabs);

                        num++;

                        if (num == 5)
                            num = 0;
                    }

                    else
                        RoadGenerator.Instance.SpawnTile(RoadGenerator.Instance.withoutTheWallTilePrefabs);
                }
                PackageManager.Instance.InsertPackage(RoadGenerator.Instance.ActiveTiles[3]);
            }
            else
                RoadGenerator.Instance.SpawnSmoothTile();
            
            if (RoadGenerator.Instance.ActiveTiles.Count > RoadGenerator.Instance.roadOnScreen)
                DeleteRoad();
        }
    }

    void DeleteRoad()
    {
        RoadGenerator.Instance.DeleteTile();
    }
    
}
