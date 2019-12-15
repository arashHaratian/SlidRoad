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
    public Canvas pauseCanvas;
    public Canvas HUDCanvas;
    public Canvas gameOverCanvas;
    public Canvas mainMenuCanvas_;
    public static PanelAndButtonsManager instance = null;
    public Canvas diamondCanvas_;
    public Canvas winCanvas_;
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
        GreenCube.countGreenCubes = PlayerPrefs.GetInt("Green Cubes Count");
    }

    //-------------------GameManager functions----------------------------------
    public void GameOver()
    {
        gameOverCanvas.enabled = true;
        HUDCanvas.enabled = false;
    }

    public void PlayMenu()
    {
        ScoreManager.score = 0;
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
        winCanvas_.enabled = false;
        diamondCanvas_.enabled = true;
        mainMenuCanvas_.enabled = true;
        pauseCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        startGameCanvas_.enabled = false;
        policyButton.gameObject.SetActive(true);
        muteButton.gameObject.SetActive(true);
        tutotrial.gameObject.SetActive(false);
    }

    public void OnStep1ButtonClick()
    {
        startGameCanvas_.enabled = true;
        mainMenuCanvas_.enabled = false;
        pauseCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        HUDCanvas.enabled = false;
       
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

