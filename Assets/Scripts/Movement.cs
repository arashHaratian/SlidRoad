using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    private Rigidbody roadMapRigidbody;
    
    void Start()
    {
        roadMapRigidbody = GetComponent<Rigidbody>();
        roadMapRigidbody.velocity = Vector3.forward * speed;

    }
}
