﻿using System.Collections;
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
    [SerializeField]private ParticleSystem playerParticle;
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

        playerParticle = player.GetComponentInChildren<ParticleSystem>();
        playerManagerScript = player.GetComponent<PlayerManager>();
    }

    private void Start()
    {
        GameAnalytics.NewDesignEvent("test");
        paused = false; 
        gameOver = false;
        gameSpeed = firstSpeed;
        Movement.Speed = Vector3.back * firstSpeed;
        RoadGenerator.Instance.Restart();
        ColorManager.instance.firstStage();

    }

    public void Restart()
    {
        playerManagerScript.enabled = false;
        playerManagerScript.enabled = true;
        Count = 0;
        if(lastRoundStarting != null)
            StopCoroutine(lastRoundStarting);
        if (lastGameLoop != null)
            StopCoroutine(lastGameLoop);
        gameOver = false;
        
        //RoadGenerator.Instance.Restart();
        //player.transform.position = new Vector3(0, 2, 2);

        Init();
    }
    public void Init()
    {
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
        PanelAndButtonsManager.instance.GameOver();
        SoundManager.instance.Reset();
        Movement.Speed = Vector3.zero;
    }

    private void OnApplicationQuit()
    {
        GameAnalyticsEvent.Instance.getLastRoadBeforeExit(RoadGenerator.Instance.CurrentRoad.name);
    }

    public void resetPlayerAndCamera()
    {
        Time.timeScale = 1;
        RoadGenerator.Instance.Restart();
        ColorManager.instance.firstStage();
        player.transform.position = new Vector3(0, 2, 5);
        playerParticle.gameObject.SetActive(false);
        playerParticle.gameObject.SetActive(true);
        gameSpeed = firstSpeed;
        Movement.Speed = Vector3.back * firstSpeed;
    }
}
