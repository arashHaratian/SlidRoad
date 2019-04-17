using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Serialization;

public class IsTrigger : MonoBehaviour
{
    // Start is called before the first frame update
     public bool collision_ ;
     private RoadGenerator _roadGenerator;
 

    private void OnTriggerEnter(Collider other)
      {
        
          if (other.gameObject.tag == "Player")
          {    
              RoadGenerator.Instance.SpawnTile();
              RoadGenerator.Instance.DeleteTile();
       
          }
      }
}
