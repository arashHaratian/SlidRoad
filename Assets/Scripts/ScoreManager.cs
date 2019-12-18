﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static float score;
    public static float highScore;
    public static int numberOfTakenGreenboxes;
    public float constScoreMult;
    public static int combo;
//    public HighscoreText gameOverHighscore;
    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
        highScore = PlayerPrefs.GetFloat("highScore");
        combo = 1;
        numberOfTakenGreenboxes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GameOver == false)
        {
            score += Time.deltaTime * constScoreMult * combo;
        }
        

        if (score > highScore)
        {
            highScore = score;
        }
    }

    private void OnEnable()
    {
        score = 0;
        combo = 1;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("highScore", highScore);;
        ShowCombo.Instance.UpdateText("","");
        numberOfTakenGreenboxes = 0;
//        gameOverHighscore.enabled = false;
//        gameOverHighscore.enabled = true;
    }
}
