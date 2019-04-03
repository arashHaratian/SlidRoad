using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float testSpeed = 100;

    public Transform playerObjectTransform;

    private Vector3 offset;

    private float turnValue;
    private string turnAxiesName = "Horizontal";

    private void Start()
    {
        offset = transform.position - playerObjectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetCamPos = playerObjectTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, 1);

        turnValue = Input.GetAxis(turnAxiesName) * testSpeed;

        offset = Quaternion.AngleAxis(turnValue , Vector3.up) * offset;

        transform.position = playerObjectTransform.position + offset;
        transform.LookAt(playerObjectTransform.position);
    }
}
