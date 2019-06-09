using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreText : MonoBehaviour
{
    [SerializeField] private Text _highScoreText;
    private float lastHighScore;
    private void Start()
    {
        _highScoreText = GetComponent<Text>();
        lastHighScore = PlayerPrefs.GetFloat("highScore");
        _highScoreText.text = ((int)lastHighScore).ToString();
    }
    private void Update()
    {
        if (lastHighScore != ScoreManager.highScore)
        {
            updateText();
            lastHighScore = ScoreManager.highScore;
        }
    }

    public void updateText()
    {
        _highScoreText.text = ((int)ScoreManager.highScore).ToString();
    }
}