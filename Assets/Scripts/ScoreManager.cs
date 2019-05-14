using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static float score;
    public static float highScore;
    public static int numberOfTakenGreenboxes;

    public static int combo;
    public static float manualSpeed;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetFloat("HighScore");
        combo = 1;
        numberOfTakenGreenboxes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * manualSpeed * combo;

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
        PlayerPrefs.SetFloat("HighScore", highScore);
        ShowCombo.Instance.UpdateText("");
        numberOfTakenGreenboxes = 0;
    }
}
