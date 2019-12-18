﻿using System;
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
    public GameOverCollider gameOverCollider;

    #region GameSpeed
    public float firstSpeed;
    private float gameSpeed;
    public float timeIncreaseSpeed;
    public float maxSpeed;
    private float Count;
    private int AdsCount;
    #endregion
    
//    [SerializeField]private ParticleSystem playerParticle;
    private Coroutine lastGameLoop;
    private Coroutine lastRoundStarting;
    private PlayerManager playerManagerScript;

    private bool gameOver;
    public bool paused;
    public bool firstTouch;
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

//        playerParticle = player.GetComponentInChildren<ParticleSystem>();
        playerManagerScript = player.GetComponent<PlayerManager>();
        gameOverCollider.enabled = false;
    }

    private void Start()
    {
        GameAnalytics.NewDesignEvent("test");
        paused = false; 
        gameOver = false;
        gameSpeed = 0;
        Movement.Speed = Vector3.zero;
        playerManagerScript.setActiceScoreManager(false);
        //RoadGenerator.Instance.Restart();
        ColorManager.instance.firstStage();

    }

    private void Update()
    {
        if (PanelAndButtonsManager.instance.HUDCanvas.enabled)
        {
            if (Input.GetMouseButton(0))
                Restart();
        }
    }

    public void Restart()
    {
        PanelAndButtonsManager.instance.tutotrial.gameObject.SetActive(false);
        playerManagerScript.SetActiveFalling(true);
            gameOverCollider.enabled = true;
            playerManagerScript.setActiceScoreManager(true);
            Count = 0;
            gameSpeed = firstSpeed;
            Movement.Speed = Vector3.back * firstSpeed;
            if(lastRoundStarting != null)
                StopCoroutine(lastRoundStarting);
            if (lastGameLoop != null)
                StopCoroutine(lastGameLoop);
            gameOver = false;
     
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

    public void GameIsOver()
    {
        if (PanelAndButtonsManager.instance.HUDCanvas.enabled)
        {
            GameAnalyticsEvent.Instance.getGameOverRoad(RoadGenerator.Instance.CurrentRoad.name);
        }
      
        GameAnalyticsEvent.Instance.getScore();
        playerManagerScript.setActiceScoreManager(false);
        PanelAndButtonsManager.instance.GameOver();
        SoundManager.instance.Reset();
        gameOverCollider.enabled = false;
        Movement.Speed = Vector3.zero;
        playerManagerScript.SetActiveFalling(false);
        if (AdsCount == 0 && GoogleMobileAdsInterstitial.Instance.interstitial.IsLoaded()) {
            GoogleMobileAdsInterstitial.Instance.interstitial.Show();
            GoogleMobileAdsInterstitial.Instance.RequestInterstitial();
        }
        AdsCount++;
        if (AdsCount == 4)
            AdsCount = 0;
    }

    public void WinTheGame()
    {
        playerManagerScript.setActiceScoreManager(false);
        PanelAndButtonsManager.instance.WinGame();
        SoundManager.instance.Reset();
        gameOverCollider.enabled = false;
        Movement.Speed = Vector3.zero;
        playerManagerScript.SetActiveFalling(false);
    }
    private void OnApplicationQuit()
    {
        if (PanelAndButtonsManager.instance.HUDCanvas.enabled)
        {
            GameAnalyticsEvent.Instance.getLastRoadBeforeExit(RoadGenerator.Instance.CurrentRoad.name);
        }
        
    }

    public void resetPlayerAndCamera()
    {
        Time.timeScale = 1;
        playerManagerScript.Reset();
        RoadGenerator.Instance.Restart();
        ColorManager.instance.firstStage();
//        playerParticle.gameObject.SetActive(false);
//        playerParticle.gameObject.SetActive(true);
        gameSpeed = 0;
        Movement.Speed = Vector3.zero;
    }
}
