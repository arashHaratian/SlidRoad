using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateRange;
//    public float speed;
    
    private float finalSpeed;


    public void Rotate(float rotate)
    {
        finalSpeed = rotate * rotateRange;
//        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0,finalSpeed,0),1);
        transform.Rotate(Vector3.up * finalSpeed);
        float y = transform.rotation.eulerAngles.y;
        if (y > rotateRange/2 && y < 180)
        {
            transform.rotation = Quaternion.Euler(0,rotateRange/2,0);
        }
        else if(y < 360 - rotateRange/2 && y >= 180)
        {
            transform.rotation = Quaternion.Euler(0,-rotateRange/2,0);
        }
    }
}
