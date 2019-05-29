using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            GameOverManager.instance.Collision();
            SoundManager.instance.GameOverCollision(0.4f);
        }
    }

    
}
