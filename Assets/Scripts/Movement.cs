using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private static float speed;
    private Rigidbody rb;
    public static float Speed
    {
        set { speed = value; }
        get { return speed; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.velocity = Vector3.forward * speed;
    }
}
