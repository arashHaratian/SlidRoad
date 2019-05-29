﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public LayerMask blockingLayer;
    public float radius;
    public float gravity;

    private Vector3 newPlayerPosition;
    private bool collision;
    private Vector3 end;
    private RaycastHit hit;
    
    private void Start()
    {
        collision = false;
    }

    void Update()
    {
        newPlayerPosition = transform.position + Vector3.down * Time.deltaTime * gravity;
        if (!IsFalling())
        {
            if(collision)
                SoundManager.instance.PlayFallingCollision(0.5f);
            collision = false;
            transform.position = hit.point + Vector3.up * radius;
        }
        else
        {
            collision = true;
            transform.position = newPlayerPosition;
        }
    }

    private bool IsFalling()
    {
        return !Physics.Linecast(transform.position, newPlayerPosition, out hit, blockingLayer);
    }
}
