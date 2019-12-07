﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PanelAndButtonsManager : MonoBehaviour
{

    //-------------------Refrences-------------------------------- 
    //mainmenu refs
    public Canvas mainMenuCanvas;
    public Image muteLine;
    public Button muteButton;
    public Button helpButton;
    public Button policyButton;
    public Slider tutotrial;

    //pasue refs
    public Canvas pauseCanvas;

    //HUD refs
    public Canvas HUDCanvas;

    // Game Over refs
    public Canvas gameOverCanvas;


    public static PanelAndButtonsManager instance = null;
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
        mainMenuCanvas.enabled = true;
        pauseCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        HUDCanvas.enabled = false;

        mainMenuCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(true);
        HUDCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(true);
    }

    //-------------------GameManager functions----------------------------------
    public void GameOver()
    {
        gameOverCanvas.enabled = true;
        HUDCanvas.enabled = false;
    }

    private void PlayMenu()
    {
        ScoreManager.score = 0;
        mainMenuCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        pauseCanvas.enabled = false;
        HUDCanvas.enabled = true;
        muteButton.gameObject.SetActive(false);
        tutotrial.gameObject.SetActive(true);
    }
    public void Restart()
    {
        GameManager.instance.paused = false;
        OpenMainMenu();
        GameManager.instance.resetPlayerAndCamera();
    }
    public void TapToPlay()
    {
        PlayMenu();
        //GameManager.instance.Restart();
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
        pauseCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        mainMenuCanvas.enabled = true;
        helpButton.gameObject.SetActive(true);
        policyButton.gameObject.SetActive(true);
        muteButton.gameObject.SetActive(true);
        tutotrial.gameObject.SetActive(false);
    }

    public void OnHelpButtonClick()
    {
        helpButton.gameObject.SetActive(false);
        policyButton.gameObject.SetActive(false);
        muteButton.gameObject.SetActive(false);
        tutotrial.gameObject.SetActive(true);
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

