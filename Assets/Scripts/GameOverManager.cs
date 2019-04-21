using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private float gameOverPossition;
    public static GameOverManager instance = null;
    private void Awake()
    {
        if (!instance)
            instance = this;
        else if(this != instance)
            Destroy(this.gameObject);
        
        gameOverPossition = -3;
    }

    private void Update()
    {
        if (PlayerManager.instance.transform.position.y < gameOverPossition)
            GameManager.instance.GameOver = true;
    }

    public void Reset()
    {
        gameOverPossition = -3;
    }

    public void CalGameOverPosition(GameObject currentRoad)
    {
        gameOverPossition = currentRoad.transform.position.y - 3;
        float cubePosition;
        for (int i = 0; i < currentRoad.transform.childCount; i++)
        {
            cubePosition = currentRoad.transform.GetChild(i).gameObject.transform.position.y;
            if(cubePosition - 3 < gameOverPossition)
                gameOverPossition = cubePosition - 3;
        }
    }
}
