using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereStaticMovement : MonoBehaviour
{

    private Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRigidbody.AddForce(0f, 0f, 100 * Time.deltaTime);
    }
}
