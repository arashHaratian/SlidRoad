using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static float score;
    public static float highScore;
    public static float bounce;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        bounce = 0;
        highScore = PlayerPrefs.GetFloat("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        score +=  Time.deltaTime *(7 + bounce);

        if (score > highScore)
        {
            highScore = score;
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
