using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject player;
    public GameObject roadMap;

    #region RatioGravity
    public float firstGravity;
    private float gravity;
    private float gravitPerSpeed;
    #endregion
    
    #region GameSpeed
    public float firstSpeed;
    private float gameSpeed;
    public float timeIncreaseSpeed;
    public float maxSpeed;
    private float Count = 0;

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
        gravitPerSpeed = firstGravity / firstSpeed;
        gravity = firstGravity;
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
        gravity = firstGravity;
        Gravity.SetGravity(gravity);
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
        MusicManager.instance.StartMusic();
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
        MusicManager.instance.increaseMusicSpeed(gameSpeed/firstSpeed);
        Count = 0;
        gravity = gameSpeed * gravitPerSpeed;
        Gravity.SetGravity(gravity);
    }

    void GameIsOver()
    {
        playerManagerScript.enabled = false;
        Time.timeScale = 0;
        PanelAndButtonsManager.instance.GameOver();
        StartCoroutine(MusicManager.instance.gameOVerEffect()); 
    }
}
