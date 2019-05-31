using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCollider : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        if(player.transform.position.z < 5)
        {
            player.transform.position += Vector3.forward * Time.deltaTime;
        }
        if (player.transform.position.z > 5f)
            player.transform.position -= Vector3.forward * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            GameManager.instance.GameOver = true;
    }
}
