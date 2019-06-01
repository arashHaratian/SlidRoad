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
    private Movement movement;
    private void Start()
    {
        firstCollision = true;
        movement = GetComponent<Movement>();
        movement.enabled = false;
    }

    void Update()
    {
        endPoint = transform.position;
        endPoint.z += radius + 0.1f;
        if (!IsCollision())
        {
            newPlayerPosition = hit.point;
            newPlayerPosition.z -= radius;
            transform.position = newPlayerPosition;
            if (firstCollision)
            {
                SoundManager.instance.GameOverCollision(0.15f);
                firstCollision = false;
                movement.enabled = true;
            }
        }

        else
        {
            firstCollision = true;
            movement.enabled = false;
        }
    }

    private bool IsCollision()
    {
           return !Physics.Linecast(transform.position + Vector3.back * 0.2f, endPoint, out hit, block);
    }
}
