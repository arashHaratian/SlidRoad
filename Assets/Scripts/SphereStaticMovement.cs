using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereStaticMovement : MonoBehaviour
{
    public float testSpeed = 100;
    private Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //playerRigidbody.AddForce(0f, 0f, testSpeed * Time.deltaTime);
         Vector3 m = new Vector3(0,0,testSpeed * Time.deltaTime);
        playerRigidbody.position += m;
    }
}
