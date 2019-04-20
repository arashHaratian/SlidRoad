using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public int gameOverHeigh = 0;
    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.instance.transform.position.y < gameOverHeigh)
            GameManager.instance.GameOver = true;
    }
}
