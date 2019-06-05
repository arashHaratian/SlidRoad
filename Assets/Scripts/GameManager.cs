using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using GameAnalyticsSDK;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject player;

    #region GameSpeed
    public float firstSpeed;
    private float gameSpeed;
    public float timeIncreaseSpeed;
    public float maxSpeed;
    private float Count = 0;

    #endregion

    private Coroutine lastGameLoop;
    private Coroutine lastRoundStarting;
    private PlayerManager playerManagerScript;
    private bool gameOver;
    public bool paused;

    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    private void Awake()
    {
        if (!instance)
            instance = this;
        else if(instance != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);

        playerManagerScript = player.GetComponent<PlayerManager>();
    }

    private void Start()
    {
        GameAnalytics.NewDesignEvent("test");
        paused = false; 
        gameOver = false;
        RoadGenerator.Instance.Restart();
    }

    public void Restart()
    {
        playerManagerScript.enabled = false;
        playerManagerScript.enabled = true;
        Count = 0;
        StopCoroutine(lastRoundStarting);
        StopCoroutine(lastGameLoop);
        gameOver = false;
        RoadGenerator.Instance.Restart();
        player.transform.position = new Vector3(0,2,5);
        PlayerManager.instance.particleEffect.SetActive(false);
        ExtraScoreText.Instance.FinishExtraScore();
        ColorManager.instance.firstStage();

        Init();
    }
    public void Init()
    {
        Time.timeScale = 1;
        lastGameLoop = StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop()
    {
        lastRoundStarting = StartCoroutine(RoundStarting());
        yield return lastRoundStarting;
        GameIsOver();        
    }

    IEnumerator RoundStarting()
    {
        gameSpeed = firstSpeed;
        Movement.Speed = Vector3.back * firstSpeed;
        while (!gameOver)
        {
            if(gameSpeed < maxSpeed)
                Count += Time.deltaTime;
                if (Count > timeIncreaseSpeed)
                    IncreaseSpeed();
            yield return null;
        }
    }

    void IncreaseSpeed()
    {
        gameSpeed += 0.5f;
        Movement.Speed -= Vector3.forward;
        Count = 0;
    }

    void GameIsOver()
    {
        GameAnalyticsEvent.Instance.getGameOverRoad(RoadGenerator.Instance.CurrentRoad.name);
        GameAnalyticsEvent.Instance.getScore();
        playerManagerScript.enabled = false;
        Time.timeScale = 0;
        PanelAndButtonsManager.instance.GameOver();
        SoundManager.instance.Reset();
    }

    private void OnApplicationQuit()
    {
        GameAnalyticsEvent.Instance.getLastRoadBeforeExit(RoadGenerator.Instance.CurrentRoad.name);
    }
}
