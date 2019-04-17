using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed;

    public float limitSpeed;

    private float finalSpeed; 
    // Update is called once per frame\

    public void Rotate(float rotate, Transform center)
    {
        finalSpeed = rotate * rotateSpeed;
        if(Math.Abs(finalSpeed) > limitSpeed)
            if (finalSpeed > 0)
                finalSpeed = limitSpeed;
            else
                finalSpeed = -1 * limitSpeed;
        transform.RotateAround(center.position, Vector3.up, finalSpeed);
        print(Math.Abs(rotate * rotateSpeed));
    }
}
