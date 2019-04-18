using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreText : MonoBehaviour
{
    public string highScoreString = "HighScore: ";
    [SerializeField] private Text _highScoreText;
    private int _lastHighScore;

//    private int currentHighScore;
    // Start is called before the first frame update
    void Start()
    {
        _highScoreText = GetComponent<Text>();
        _lastHighScore = (int)PlayerPrefs.GetFloat("HighScore");
        _highScoreText.text = highScoreString + ((int)_lastHighScore).ToString();
//        currentHighScore = (int)ScoreManager.highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (_lastHighScore != (int)ScoreManager.highScore)
            setHighScoreText();
    }

    private void setHighScoreText()
    {
        _lastHighScore = (int)ScoreManager.highScore;
        _highScoreText.text = highScoreString + _lastHighScore;
    }
}
