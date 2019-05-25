using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public float gameOverHeight;
    public static GameOverManager instance = null;

    
    private void Awake()
    {
        if (!instance)
            instance = this;
        else if(this != instance)
            Destroy(this.gameObject);
    }

    private void Update()
    {
        if (PlayerManager.instance.transform.position.y < gameOverHeight)
            GameManager.instance.GameOver = true;
    }

    public void Collision()
    {
        GameManager.instance.GameOver = true;
    }
}
