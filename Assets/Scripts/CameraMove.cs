using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 defualtPosition;

    public float smoothing = 5f;
    public Transform target;

    Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = defualtPosition;
        offset = transform.position - target.position;
    }

    public void Reset()
    {
        transform.position = defualtPosition;
    }

    public void Move(float Movement)
    {
        transform.position += Vector3.right * Movement;
    }

    private void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        targetCamPos.x = transform.position.x;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
