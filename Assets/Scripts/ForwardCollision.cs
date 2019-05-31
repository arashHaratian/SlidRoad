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
    private bool firstCollision;

    private void Start()
    {
        firstCollision = true;
    }

    void Update()
    {
        endPoint = transform.position;
        endPoint.z += radius + 0.05f;
        if (!IsCollision())
        {
            newPlayerPosition = hit.point;
            newPlayerPosition.z -= radius;
            transform.position = newPlayerPosition;
            if (firstCollision)
            {
                SoundManager.instance.GameOverCollision(0.15f);
                firstCollision = false;
            }
        }
        
        else
            firstCollision = true;
    }

    private bool IsCollision()
    {
           return !Physics.Linecast(transform.position, endPoint, out hit, block);
    }
}
