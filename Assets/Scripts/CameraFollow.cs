using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerObjectTransform;

    private Vector3 offset;
    private void Start()
    {
        offset = transform.position - playerObjectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetCamPos = playerObjectTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, 1);
    }
}
