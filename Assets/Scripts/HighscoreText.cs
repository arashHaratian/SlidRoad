using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreText : MonoBehaviour
{
    [SerializeField] private Text _highScoreText;
    private float lastHighScore1;
    private float lastHighScore2;
    private float lastHighScore3;
    private float lastHighScore4;
    private float lastHighScore5;
    private float lastHighScore6;
    private float lastHighScore7;
    private float lastHighScore8;
    private float lastHighScore9;
    private float lastHighScore10;
    private void Start()
    {
        _highScoreText = GetComponent<Text>();
        
        if (PanelAndButtonsManager.instance.step1)
        {
            lastHighScore1 = PlayerPrefs.GetFloat("highScore1");
            _highScoreText.text = ((int)lastHighScore1).ToString();
        }
        
        if (PanelAndButtonsManager.instance.step2)
        {
            lastHighScore2 = PlayerPrefs.GetFloat("highScore2");
            _highScoreText.text = ((int)lastHighScore2).ToString();
        }

        if (PanelAndButtonsManager.instance.step3)
        {
            lastHighScore3 = PlayerPrefs.GetFloat("highScore3");
            _highScoreText.text = ((int)lastHighScore3).ToString();
        }
        
        if (PanelAndButtonsManager.instance.step4)
        {
            lastHighScore4 = PlayerPrefs.GetFloat("highScore4");
            _highScoreText.text = ((int)lastHighScore4).ToString();
        }
        
        if (PanelAndButtonsManager.instance.step5)
        {
            lastHighScore5 = PlayerPrefs.GetFloat("highScore5");
            _highScoreText.text = ((int)lastHighScore5).ToString();
        }
        
        if (PanelAndButtonsManager.instance.step6)
        {
            lastHighScore6 = PlayerPrefs.GetFloat("highScore6");
            _highScoreText.text = ((int)lastHighScore6).ToString();
        }
        
        if (PanelAndButtonsManager.instance.step7)
        {
            lastHighScore7 = PlayerPrefs.GetFloat("highScore7");
            _highScoreText.text = ((int)lastHighScore7).ToString();
        }
        
        if (PanelAndButtonsManager.instance.step8)
        {
            lastHighScore8 = PlayerPrefs.GetFloat("highScore8");
            _highScoreText.text = ((int)lastHighScore8).ToString();
        }
        
        if (PanelAndButtonsManager.instance.step9)
        {
            lastHighScore9 = PlayerPrefs.GetFloat("highScore9");
            _highScoreText.text = ((int)lastHighScore9).ToString();
        }
        
        if (PanelAndButtonsManager.instance.step10)
        {
            lastHighScore10 = PlayerPrefs.GetFloat("highScore10");
            _highScoreText.text = ((int)lastHighScore10).ToString();
        }

        
    }

    private void Update()
    {
        if (PanelAndButtonsManager.instance.step1 || lastHighScore1 != ScoreManager.highScore1)
        {
            updateText();
            lastHighScore1 = ScoreManager.highScore1;
        }
        
        if (PanelAndButtonsManager.instance.step2 || lastHighScore2 != ScoreManager.highScore2)
        {
            updateText();
            lastHighScore2 = ScoreManager.highScore2;
        }
        
        if (PanelAndButtonsManager.instance.step3 || lastHighScore3 != ScoreManager.highScore3)
        {
            updateText();
            lastHighScore3 = ScoreManager.highScore3;
        }
        
        if (PanelAndButtonsManager.instance.step4 || lastHighScore4 != ScoreManager.highScore4)
        {
            updateText();
            lastHighScore4 = ScoreManager.highScore4;
        }
        
        if (PanelAndButtonsManager.instance.step5 || lastHighScore5 != ScoreManager.highScore5)
        {
            updateText();
            lastHighScore5 = ScoreManager.highScore5;
        }
        
        if (PanelAndButtonsManager.instance.step6 || lastHighScore6 != ScoreManager.highScore6)
        {
            updateText();
            lastHighScore6 = ScoreManager.highScore6;
        }
        
        if (PanelAndButtonsManager.instance.step7 || lastHighScore7 != ScoreManager.highScore7)
        {
            updateText();
            lastHighScore7 = ScoreManager.highScore7;
        }
        
        if (PanelAndButtonsManager.instance.step8 || lastHighScore8 != ScoreManager.highScore8)
        {
            updateText();
            lastHighScore8 = ScoreManager.highScore8;
        }
        
        if (PanelAndButtonsManager.instance.step9 || lastHighScore9 != ScoreManager.highScore9)
        {
            updateText();
            lastHighScore9 = ScoreManager.highScore9;
        }
        
        if (PanelAndButtonsManager.instance.step10 || lastHighScore10 != ScoreManager.highScore10)
        {
            updateText();
            lastHighScore10 = ScoreManager.highScore10;
        }
        
    }




    public void updateText()
    {
        if (PanelAndButtonsManager.instance.step1)
        _highScoreText.text = ((int)ScoreManager.highScore1).ToString();
        
        
        if (PanelAndButtonsManager.instance.step2)
            _highScoreText.text = ((int)ScoreManager.highScore2).ToString();
        
        
        if (PanelAndButtonsManager.instance.step3)
            _highScoreText.text = ((int)ScoreManager.highScore3).ToString();
        
        
        if (PanelAndButtonsManager.instance.step4)
            _highScoreText.text = ((int)ScoreManager.highScore4).ToString();
        
        
        if (PanelAndButtonsManager.instance.step5)
            _highScoreText.text = ((int)ScoreManager.highScore5).ToString();
        
        
        if (PanelAndButtonsManager.instance.step6)
            _highScoreText.text = ((int)ScoreManager.highScore6).ToString();
        
        
        if (PanelAndButtonsManager.instance.step7)
            _highScoreText.text = ((int)ScoreManager.highScore7).ToString();
        
        
        if (PanelAndButtonsManager.instance.step8)
            _highScoreText.text = ((int)ScoreManager.highScore8).ToString();
        
        
        if (PanelAndButtonsManager.instance.step9)
            _highScoreText.text = ((int)ScoreManager.highScore9).ToString();
        
        
        if (PanelAndButtonsManager.instance.step10)
            _highScoreText.text = ((int)ScoreManager.highScore10).ToString();
        
    }
}