using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public string scoreString;

    private Text _scoreText;
    //private ScoreManager _scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreString = "Score: ";
        _scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = scoreString + (int)ScoreManager.score;
    }
}
