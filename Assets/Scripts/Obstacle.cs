using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float sideCubeSize;
    public float ballRadius;
    private Vector3 playerPosition;
    private Vector3 cubePosition;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerPosition = PlayerManager.instance.transform.position;
            cubePosition = transform.position;
//            if (playerPosition.x < cubePosition.x + (sideCubeSize / 2) &&
//                playerPosition.x > cubePosition.x - (sideCubeSize / 2))
//                ForwardCollision();
            if (playerPosition.x > cubePosition.x)
                RightCollision();
            else if (playerPosition.x < cubePosition.x)
                LeftCollision();
        }
    }
    private void RightCollision()
    {
        print("write");
        playerPosition.x = cubePosition.x + sideCubeSize / 2 + ballRadius;
        PlayerManager.instance.transform.position = playerPosition;
    }

    private void LeftCollision()
    {
        print("left");
        playerPosition.x = cubePosition.x - sideCubeSize / 2 - ballRadius;
        PlayerManager.instance.transform.position = playerPosition;
    }
    private void ForwardCollision()
    {
        print("forward");
//        GameOverManager.instance.Collision();
    }
    
}
