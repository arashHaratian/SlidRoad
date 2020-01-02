using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameOverHeight : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameOverManager.instance.CalGameOverPosition(RoadGenerator.Instance.CurrentRoad);
            PackageManager.Instance.InsertPackage(RoadGenerator.Instance.ActiveTiles[1]);
        }
        
    }
}
