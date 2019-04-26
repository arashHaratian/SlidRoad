﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject player;
    public GameObject roadMap;
    #region GameSpeed

    public float gameSpeed;
    public float timeIncreaseSpeed;
    public float maxSpeed;
    private float lastTime;

    #endregion
    
    private PlayerManager playerManagerScript;
    private bool gameOver;

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
        gameOver = false;
        RoadGenerator.Instance.Restart();
    }

    public void Restart()
    {
        playerManagerScript.enabled = false;
        playerManagerScript.enabled = true;
        roadMap.transform.rotation = Quaternion.identity;
        gameOver = false;
        RoadGenerator.Instance.Restart();
        player.transform.position = Vector3.up * 3;
        GameOverManager.instance.Reset();
        Init();
    }
    public void Init()
    {
        Time.timeScale = 1;
        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        GameIsOver();        
    }

    IEnumerator RoundStarting()
    {
        lastTime = Time.time;
        Movement.Speed = Vector3.back * gameSpeed;
        while (!gameOver)
        {
            print(Movement.Speed.z );
            if(gameSpeed < maxSpeed)
                if (lastTime + timeIncreaseSpeed < Time.time)
                    IncreaseSpeed();
            yield return null;
        }
    }

    void IncreaseSpeed()
    {
        gameSpeed++;
        Movement.Speed -= Vector3.forward;
        lastTime = Time.time;
        Physics.gravity += Vector3.down;
    }

    void GameIsOver()
    {
        playerManagerScript.enabled = false;
        Time.timeScale = 0;
        PanelAndButtonsManager.instance.GameOver();
    }
}
