using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public static float  gravitySpeed;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gravitySpeed = GameManager.instance.firstGravity;
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.down * gravitySpeed;
    }
    static public void SetGravity(float gravitySpeed)
    {        
        Gravity.gravitySpeed = gravitySpeed;
    }
}
