using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateRange;
   private float finalSpeed; 
    // Update is called once per frame\

    public void Rotate(float rotate, Transform center)
    {
        finalSpeed = rotate * rotateRange;
        transform.RotateAround(center.position, Vector3.up, finalSpeed);
    }
}
