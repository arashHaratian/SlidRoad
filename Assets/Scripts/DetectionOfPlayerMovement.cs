using System.Collections;
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
            if (RoadGenerator.Instance.counts - 1 < RoadGenerator.Instance.easyTilePrefabs.Length)
                RoadGenerator.Instance.SpawnTile(RoadGenerator.Instance.easyTilePrefabs);   

            else
            {
                if (num == 0)
                 RoadGenerator.Instance.SpawnTile(RoadGenerator.Instance.easyTilePrefabs);    

                else if (num == 1 || num == 2)
                    RoadGenerator.Instance.SpawnTile(RoadGenerator.Instance.mediumTilePrefabs);
                
                else if(num >= 3)
                  RoadGenerator.Instance.SpawnTile(RoadGenerator.Instance.hardTilePrefabs);

                  num++;
                  
                  if (num == 6)
                   num = 0;
            }
            
            if (RoadGenerator.Instance.ActiveTiles.Count > RoadGenerator.Instance.roadOnScreen)
                DeleteRoad();
            GameOverManager.instance.CalGameOverPosition(RoadGenerator.Instance.CurrentRoad);
            PackageManager.Instance.InsertPackage(RoadGenerator.Instance.CurrentRoad);
        }
    }

    void DeleteRoad()
    {
        RoadGenerator.Instance.DeleteTile();
    }
    
}
