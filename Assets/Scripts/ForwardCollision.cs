using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardCollision : MonoBehaviour
{
    public LayerMask block;
    public float radius;

    private Vector3 endPoint;
    private RaycastHit hit;
    private Vector3 newPlayerPosition;
    
    void Update()
    {
        endPoint = transform.position;
        endPoint.z += radius + 0.05f;
        if (!IsCollision())
        {
            newPlayerPosition = hit.point;
            newPlayerPosition.z -= radius;
            transform.position = newPlayerPosition;
        }
    }

    private bool IsCollision()
    {
           return !Physics.Linecast(transform.position, endPoint, out hit, block);
    }
}
