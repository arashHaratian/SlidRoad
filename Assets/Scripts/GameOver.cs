using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public int gameOverHeigh = 0;
    public GameObject lowestCube;

    private float gameOverPossition;
    private void Start()
    {
        gameOverPossition = lowestCube.transform.position.y - 4;
    }

    void Update()
    {
        if (PlayerManager.instance.transform.position.y < gameOverPossition)
            GameManager.instance.GameOver = true;
    }
}
