using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static float score1;
    public static float score2;
    public static float score3;
    public static float score4;
    public static float score5;
    public static float score6;
    public static float score7;
    public static float score8;
    public static float score9;
    public static float score10;
    public static float highScore1;
    public static float highScore2;
    public static float highScore3;
    public static float highScore4;
    public static float highScore5;
    public static float highScore6;
    public static float highScore7;
    public static float highScore8;
    public static float highScore9;
    public static float highScore10;
    public static int numberOfTakenGreenboxes;
    public float constScoreMult;
    public static int combo;
//    public HighscoreText gameOverHighscore;
    // Start is called before the first frame update
    void Awake()
    {
        score1 = 0;
        score2 = 0;
        score3 = 0;
        score4 = 0;
        score5 = 0;
        score6 = 0;
        score7 = 0;
        score8 = 0;
        score9 = 0;
        score10 = 0;
        highScore1 = PlayerPrefs.GetFloat("highScore1");
        highScore2 = PlayerPrefs.GetFloat("highScore2");
        highScore3 = PlayerPrefs.GetFloat("highScore3");
        highScore4 = PlayerPrefs.GetFloat("highScore4");
        highScore5 = PlayerPrefs.GetFloat("highScore5");
        highScore6 = PlayerPrefs.GetFloat("highScore6");
        highScore7 = PlayerPrefs.GetFloat("highScore7");
        highScore8 = PlayerPrefs.GetFloat("highScore8");
        highScore9 = PlayerPrefs.GetFloat("highScore9");
        highScore10 = PlayerPrefs.GetFloat("highScore10");
        combo = 1;
        numberOfTakenGreenboxes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GameOver == false && GameManager.instance.iswinTheGame == false)
        {
            if (PanelAndButtonsManager.instance.step1) 
                score1 += Time.deltaTime * constScoreMult * combo;
            
            if (PanelAndButtonsManager.instance.step2) 
                score2 += Time.deltaTime * constScoreMult * combo;
            
            if (PanelAndButtonsManager.instance.step3) 
                score3 += Time.deltaTime * constScoreMult * combo;
            
            if (PanelAndButtonsManager.instance.step4) 
                score4 += Time.deltaTime * constScoreMult * combo;
            
            if (PanelAndButtonsManager.instance.step5) 
                score5 += Time.deltaTime * constScoreMult * combo;
            
            if (PanelAndButtonsManager.instance.step6) 
                score6 += Time.deltaTime * constScoreMult * combo;
            
            if (PanelAndButtonsManager.instance.step7) 
                score7 += Time.deltaTime * constScoreMult * combo;
            
            if (PanelAndButtonsManager.instance.step8) 
                score8 += Time.deltaTime * constScoreMult * combo;
            
            if (PanelAndButtonsManager.instance.step9) 
                score9 += Time.deltaTime * constScoreMult * combo;

            if (PanelAndButtonsManager.instance.step10) 
                score10 += Time.deltaTime * constScoreMult * combo;

        }
        

        if (PanelAndButtonsManager.instance.step1 && score1 > highScore1)
        {
            highScore1 = score1;
        }
        
        if (PanelAndButtonsManager.instance.step2 && score2 > highScore2)
        {
            highScore2 = score2;
        }
        
        if (PanelAndButtonsManager.instance.step3 && score3 > highScore3)
        {
            highScore3 = score3;
        }
        
        if (PanelAndButtonsManager.instance.step4 && score4 > highScore4)
        {
            highScore4 = score4;
        }
        
        if (PanelAndButtonsManager.instance.step5 && score5 > highScore5)
        {
            highScore5 = score5;
        }
        
        if (PanelAndButtonsManager.instance.step6 && score6 > highScore6)
        {
            highScore6 = score6;
        }

        if (PanelAndButtonsManager.instance.step7 && score7 > highScore7)
        {
            highScore7 = score7;
        }
        
        if (PanelAndButtonsManager.instance.step8 && score8 > highScore8)
        {
            highScore8 = score8;
        }
        
        if (PanelAndButtonsManager.instance.step9 && score9 > highScore9)
        {
            highScore9 = score9;
        }
        
         
        if (PanelAndButtonsManager.instance.step10 && score10 > highScore10)
        {
            highScore10 = score10;
        }
        
    }

    private void OnEnable()
    {
        score1 = 0;
        score2 = 0;
        score3 = 0;
        score4 = 0;
        score5 = 0;
        score6 = 0;
        score7 = 0;
        score8 = 0;
        score9 = 0;
        score10 = 0;
        combo = 1;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("highScore1", highScore1);;
        PlayerPrefs.SetFloat("highScore2", highScore2);;
        PlayerPrefs.SetFloat("highScore3", highScore3);;
        PlayerPrefs.SetFloat("highScore4", highScore4);;
        PlayerPrefs.SetFloat("highScore5", highScore5);;
        PlayerPrefs.SetFloat("highScore6", highScore6);;
        PlayerPrefs.SetFloat("highScore7", highScore7);;
        PlayerPrefs.SetFloat("highScore8", highScore8);;
        PlayerPrefs.SetFloat("highScore9", highScore9);;
        PlayerPrefs.SetFloat("highScore10", highScore10);;
        ShowCombo.Instance.UpdateText("","");
        numberOfTakenGreenboxes = 0;
//        gameOverHighscore.enabled = false;
//        gameOverHighscore.enabled = true;
    }
}
