﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Serialization;

public class IsTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {    
            RoadGenerator.Instance.SpawnTile();
            Invoke("DeleteRoad",4f); 
        }
    }

    void DeleteRoad()
    {
        RoadGenerator.Instance.DeleteTile();
    }
    
}
