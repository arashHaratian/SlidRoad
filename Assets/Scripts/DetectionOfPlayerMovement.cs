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
                if (num <= 3)
                 RoadGenerator.Instance.SpawnTile(RoadGenerator.Instance.easyTilePrefabs);    

             //   else if (num == 1 || num == 4)
//                    RoadGenerator.Instance.SpawnTile(RoadGenerator.Instance.mediumTilePrefabs);
//                
                else if(num >= 4)
                  RoadGenerator.Instance.SpawnTile(RoadGenerator.Instance.hardTilePrefabs);

                  num++;
                  
                  if (num == 8)
                   num = 0;
            }
            
            if (RoadGenerator.Instance.ActiveTiles.Count > RoadGenerator.Instance.roadOnScreen)
                DeleteRoad();
            PackageManager.Instance.InsertPackage(RoadGenerator.Instance.ActiveTiles[3]);
        }
    }

    void DeleteRoad()
    {
        RoadGenerator.Instance.DeleteTile();
    }
    
}
