using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static float score;
    public static float highScore;
    public Text scoreText;
    public Text highScoreText;

    private string scoreString;
    private string highScoreString;
    // Start is called before the first frame update
    void Start()
    {
        scoreString = "Score: ";
        highScoreString = "Highscore: ";
        highScore = PlayerPrefs.GetFloat("HighScore");
        scoreText.text = scoreString + 0.ToString();
        highScoreText.text = highScoreString + ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * 7;
        scoreText.text = scoreString + ((int)score).ToString();

        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = highScoreString + ((int)highScore) .ToString();
        }
       
       
    }

    private void OnEnable()
    {
        score = 0;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("HighScore", highScore);
    }
}
