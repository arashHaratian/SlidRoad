using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed;
    // Update is called once per frame\
    public void Rotate(float rotate, Transform center)
    {
        transform.RotateAround(center.position, Vector3.up, rotateSpeed * rotate);
    }
}
