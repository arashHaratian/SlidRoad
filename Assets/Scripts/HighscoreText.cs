using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreText : MonoBehaviour
{
    [SerializeField] private Text _highScoreText;

    public void OnEnable()
    {
        _highScoreText = GetComponent<Text>();
        _highScoreText.text = ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
    }
}