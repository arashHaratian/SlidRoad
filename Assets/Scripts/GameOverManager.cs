using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public float gameOverHeight;
    private float gameOverPossition;
    public static GameOverManager instance = null;
    private void Awake()
    {
        if (!instance)
            instance = this;
        else if (this != instance)
            Destroy(this.gameObject);

        gameOverPossition = gameOverHeight;
    }

    private void Update()
    {
        if (PlayerManager.instance.transform.position.y < gameOverPossition)
        {
            GameManager.instance.GameOver = true;
            GameManager.instance.GameIsOver();
        }
          
    }

    public void Reset()
    {
        gameOverPossition = gameOverHeight;
    }

    public void CalGameOverPosition(GameObject currentRoad)
    {
        if (PanelAndButtonsManager.instance.HUDCanvas.enabled)
        {
            gameOverPossition = currentRoad.transform.position.y + gameOverHeight;
            float cubePosition;
            for (int i = 0; i < currentRoad.transform.childCount; i++)
            {
                cubePosition = currentRoad.transform.GetChild(i).gameObject.transform.position.y;
                if (cubePosition + gameOverHeight < gameOverPossition)
                    gameOverPossition = cubePosition + gameOverHeight;
            }
        }
        }
        
}
