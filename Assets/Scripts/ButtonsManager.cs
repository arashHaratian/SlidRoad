using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ButtonsManager : MonoBehaviour
{
    //pasue refs
    public Canvas pauseCanvas;

    //mainmenu refs
    public Canvas mainMenuCanvas;

    //HUD refs
    public Canvas HUDCanves;

    private void Start()
    {
        pauseCanvas.enabled = false;
        HUDCanves.enabled = false;
        mainMenuCanvas.enabled = true;
        Time.timeScale = 0;
    }

    //pasue buttons
    public void PauseOrResume()
    {
        pauseCanvas.enabled = !pauseCanvas.enabled;
        HUDCanves.enabled = !HUDCanves.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //start menu buttons
    public void StartGame()
    {
        mainMenuCanvas.enabled = !mainMenuCanvas.enabled;
        HUDCanves.enabled = true;
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    }

}
