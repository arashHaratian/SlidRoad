using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Serialization;

public class DetectionOfPlayerMovement : MonoBehaviour
{
//    public static int num;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RoadGenerator.Instance.DeleteTile();
            GameOverManager.instance.CalGameOverPosition(RoadGenerator.Instance.CurrentRoad);
            PackageManager.Instance.InsertPackage(RoadGenerator.Instance.ActiveTiles[1]);
        }
        
    }
}