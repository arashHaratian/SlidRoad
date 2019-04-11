using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ButtonsManager : MonoBehaviour
{

    //-------------------Refrences-------------------------------- 
    //mainmenu refs
    public Canvas mainMenuCanvas;

    //pasue refs
    public Canvas pauseCanvas;

    //HUD refs
    public Canvas HUDCanves;

    // Game Over refs
    public Canvas gameOverCanves;

    //-----------------------------------------------------
    private void Start()
    {
        mainMenuCanvas.enabled = true;
        pauseCanvas.enabled = false;
        gameOverCanves.enabled = false;
        HUDCanves.enabled = false;
    }
    //-------------------GameManager functions----------------------------------
    public void GameOver()
    {
        gameOverCanves.enabled = true;
        HUDCanves.enabled = false;
    }

    public void TapToPlay()
    {
        mainMenuCanvas.enabled = false;
        HUDCanves.enabled = true;
        mainMenuCanvas.gameObject.SetActive(false);
        //GameManager.instance.init();
    }
    //-----------------------------------------------------

    //-------------------Buttons Functions----------------------------------

    public void SettingsButton()
    {
        print("Setting canves Not Found");
    }

    public void Resume()
    {
        pauseCanvas.enabled = false;
        HUDCanves.enabled = true;
        Time.timeScale = 1;
    }

    public void Pause()
    {
        pauseCanvas.enabled = true;
        HUDCanves.enabled = false;
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
        gameOverCanves.enabled = false;
        mainMenuCanvas.enabled = true;
    }
}

