﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCollider : MonoBehaviour
{
    public float sppedOfComingBack;
    public float sppedOfComingForward;
    public GameObject roadMap;
    public GameObject player;

    private void Update()
    {
        if(player.transform.position.z < 8)
        {
            player.transform.position += Vector3.forward * Time.deltaTime * sppedOfComingForward;
            roadMap.transform.position += Vector3.forward * Time.deltaTime * sppedOfComingForward;
        }

        if (player.transform.position.z > 8.1f)
        {
            player.transform.position -= Vector3.forward * Time.deltaTime * sppedOfComingBack;
            roadMap.transform.position -= Vector3.forward * Time.deltaTime * sppedOfComingBack;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            GameManager.instance.GameOver = true;
    }
}
