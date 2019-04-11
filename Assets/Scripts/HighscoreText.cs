using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreText : MonoBehaviour
{
    public string highScoreString = "HighScore: ";
    [SerializeField] private Text _highScoreText;
    private float _lastHighScore;
    // Start is called before the first frame update
    void Start()
    {
        _highScoreText = GetComponent<Text>();
        _lastHighScore = PlayerPrefs.GetFloat("HighScore");
        _highScoreText.text = highScoreString + ((int)_lastHighScore).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (_lastHighScore != PlayerPrefs.GetFloat("HighScore"))
            setHighScoreText();
    }

    private void setHighScoreText()
    {
        _lastHighScore = PlayerPrefs.GetFloat("HighScore");
        _highScoreText.text = highScoreString + ((int)_lastHighScore).ToString();
    }
}
