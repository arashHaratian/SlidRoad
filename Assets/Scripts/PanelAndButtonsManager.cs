using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PanelAndButtonsManager : MonoBehaviour
{

    //-------------------Refrences-------------------------------- 
    //mainmenu refs
    public Canvas startGameCanvas_;
    public Image muteLine;
    public Button muteButton;
    public Button policyButton;
    public Slider tutotrial;
    public Button step1Button_;
    public Button step2Button_;
    public Button step3Button_;
    public Button step4Button_;
    public Button step5Button_;
    public Button step6Button_;
    public Button step7Button_;
    public Button step8Button_;
    public Button step9Button_;
    public Button step10Button_;
    public Canvas pauseCanvas;
    public Canvas HUDCanvas;
    public Canvas gameOverCanvas;
    public Canvas mainMenuCanvas_;
    public static PanelAndButtonsManager instance = null;
    public Canvas diamondCanvas_;
    public Canvas winCanvas_;
    public bool step1;
    public bool step2;
    public bool step3;
    public bool step4;
    public bool step5;
    public bool step6;
    public bool step7;
    public bool step8;
    public bool step9;
    public bool step10;
    //-----------------------------------------------------
    private void Awake()
    {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(this);
        
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        RoadGenerator.Instance.Restart();
        Movement.Speed = Vector3.back * 5;
        PlayerManager.instance.gameObject.SetActive(false);
        startGameCanvas_.enabled = false;
        pauseCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        HUDCanvas.enabled = false;
        winCanvas_.enabled = false;

        startGameCanvas_.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(true);
        HUDCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(true);
        diamondCanvas_.gameObject.SetActive(true);
        winCanvas_.gameObject.SetActive(true);
        mainMenuCanvas_.gameObject.SetActive(true);
        GreenCube.countGreenCubes = PlayerPrefs.GetInt("Green Cubes Count");
    }

    //-------------------GameManager functions----------------------------------
    public void GameOver()
    {
        if (mainMenuCanvas_.enabled == false && startGameCanvas_.enabled == false)
        {
            gameOverCanvas.enabled = true;
            HUDCanvas.enabled = false;
        }
       
    }

    public void WinGame()
    {
        winCanvas_.enabled = true;
        HUDCanvas.enabled = false;

    }
    public void PlayMenu()
    {
        ScoreManager.score1 = 0;
        ScoreManager.score2 = 0;
        ScoreManager.score3 = 0;
        ScoreManager.score4 = 0;
        ScoreManager.score5 = 0;
        ScoreManager.score6 = 0;
        ScoreManager.score7 = 0;
        ScoreManager.score8 = 0;
        ScoreManager.score9 = 0;
        ScoreManager.score10 = 0;
        startGameCanvas_.enabled = false;
        gameOverCanvas.enabled = false;
        pauseCanvas.enabled = false;
        HUDCanvas.enabled = true;
        muteButton.gameObject.SetActive(false);
        tutotrial.gameObject.SetActive(true);
    }
    
    public void Restart()
    {
        GameManager.instance.paused = false;
        GameManager.instance.resetPlayerAndCamera();
    }
    
   
    //-----------------------------------------------------

    //-------------------Buttons Functions----------------------------------

    public void SettingsButton()
    {
        print("Setting canvas Not Found");
    }

    public void Resume()
    {
        GameManager.instance.paused = false;
        pauseCanvas.enabled = false;
        HUDCanvas.enabled = true;
        Time.timeScale = 1;
    }

    public void Pause()
    {
        GameManager.instance.paused = true;
        pauseCanvas.enabled = true;
        HUDCanvas.enabled = false;
        Time.timeScale = 0;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }


    public void OpenMainMenu()
    {
        Restart();
        GameManager.instance.iswinTheGame = false;
        GameManager.instance.GameOver = false;
        RoadGenerator.Instance.Restart();
        Movement.Speed = Vector3.back * 5;

        PlayerManager.instance.gameObject.SetActive(false);
        winCanvas_.enabled = false;
        diamondCanvas_.enabled = true;
        mainMenuCanvas_.enabled = true;
        pauseCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        startGameCanvas_.enabled = false;
        policyButton.gameObject.SetActive(true);
        muteButton.gameObject.SetActive(true);
        tutotrial.gameObject.SetActive(false);
        step1 = false;
        step2 = false;
        step3 = false;
        step4 = false;
        step5 = false;
        step6 = false;
        step7 = false;
        step8 = false;
        step9 = false;
        step10 = false;
    }

    public void OnStep1ButtonClick()
    {
        step1 = true;
        ClickButtonSteps();
    }

    public void OnStep2ButtonClick()
    {
        step2 = true;
        ClickButtonSteps();
    }
    
    public void OnStep3ButtonClick()
    {
        step3 = true;
        ClickButtonSteps();
    }
    
    public void OnStep4ButtonClick()
    {
        step4 = true;
        ClickButtonSteps();
    }
    
    public void OnStep5ButtonClick()
    {
        step5 = true;
        ClickButtonSteps();
    }
    
    public void OnStep6ButtonClick()
    {
        step6 = true;
        ClickButtonSteps();
    }
    
    public void OnStep7ButtonClick()
    {
        step7 = true;
        ClickButtonSteps();
    }
    
    public void OnStep8ButtonClick()
    {
        step8 = true;
        ClickButtonSteps();
    }
    
    public void OnStep9ButtonClick()
    {
        step9 = true;
        ClickButtonSteps();
    }
    
    public void OnStep10ButtonClick()
    {
        step10 = true;
        ClickButtonSteps();
    }

    private void ClickButtonSteps()
    {
        PlayerManager.instance.gameObject.SetActive(true);
        gameOverCanvas.enabled = false;
        startGameCanvas_.enabled = true;
        mainMenuCanvas_.enabled = false;
        pauseCanvas.enabled = false;
        HUDCanvas.enabled = false;
        
    }
    public void PlayAgainGame()
    {
        GameManager.instance.iswinTheGame = false;
        GameManager.instance.GameOver = false;
        winCanvas_.enabled = false;
        Restart();
        
        if (step1)
        {
            step1Button_.enabled = true;
            OnStep1ButtonClick();
        }
        
        if (step2)
        {
            step2Button_.enabled = true;
            OnStep2ButtonClick();
        }
        
        if (step3)
        {
            step3Button_.enabled = true;
            OnStep3ButtonClick();
        }
        
        if (step4)
        {
            step4Button_.enabled = true;
            OnStep4ButtonClick();
        }
        
        if (step5)
        {
            step5Button_.enabled = true;
            OnStep5ButtonClick();
        }
        
        if (step6)
        {
            step6Button_.enabled = true;
            OnStep6ButtonClick();
        }
        
        if (step7)
        {
            step7Button_.enabled = true;
            OnStep7ButtonClick();
        }
        
        if (step8)
        {
            step8Button_.enabled = true;
            OnStep8ButtonClick();
        }
        
        if (step9)
        {
            step9Button_.enabled = true;
            OnStep9ButtonClick();
        }
        
        if (step10)
        {
            step10Button_.enabled = true;
            OnStep10ButtonClick();
        }
    }
    
    public void OnMuteButtonClick()
    {
        SoundManager.instance.Mute(muteLine.IsActive());
        muteLine.enabled = !muteLine.IsActive();
    }
    
    public void openPrivacyPalicy()
    {
        Application.OpenURL("https://www.joyixir.com/privacy/slidroad.html");   
    }
    
}

