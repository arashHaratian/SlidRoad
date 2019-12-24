using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleInEndGame : MonoBehaviour
{
    
    public ParticleSystem effect1;
    public ParticleSystem effect2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(effect1);
            effect1.Play();
            
            Instantiate(effect2);
            effect2.Play();
        }
    }
}
