using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 defualtPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = defualtPosition;
    }

    public void Reset()
    {
        transform.position = defualtPosition;
    }

    public void Move(float Movement)
    {
        transform.position += Vector3.right * Movement;
    }
}
