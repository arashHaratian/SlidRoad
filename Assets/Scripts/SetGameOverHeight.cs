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
            RoadGenerator.Instance.CurrentRoad = transform.parent.gameObject;
            GameOverManager.instance.CalGameOverPosition(RoadGenerator.Instance.CurrentRoad);
            
        }
        
    }
}
