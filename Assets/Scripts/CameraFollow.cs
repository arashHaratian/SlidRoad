using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothing = 5f;
    public Transform target;

    private float lastAngle = 0;

    Vector3 offset;
    public static CameraFollow Instance;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else if(Instance != this)
            Destroy(this.gameObject);
    }
    private void Start()
    {
        offset = transform.position - target.position;
        offset.y += 2;
    }
    private void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
