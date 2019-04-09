using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class RandomTitle : MonoBehaviour
{
    public GameObject title1;
    public GameObject title2;
    private int Num;

    void Start()
    {
        Num = Random.Range(1, 2);
        
        if (Num == 1)
        {
            Instantiate(title1, transform.position, transform.rotation);
        }

        else if (Num == 2)
        {
            Instantiate(title2, transform.position, transform.rotation);
        }
    }
  
}
