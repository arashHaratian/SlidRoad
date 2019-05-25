using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreText : MonoBehaviour
{
    public string highScoreString = "HighScore: ";
    [SerializeField] private Text _highScoreText;

    public void OnEnable()
    {
        _highScoreText = GetComponent<Text>();
        _highScoreText.text = highScoreString + ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
    }
}