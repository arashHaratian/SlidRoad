using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject player;

    #region GameSpeed

    public Vector3 gameSpeed;
    public float timeIncreaseSpeed;
    private float lastTime;

    #endregion
    
    private Rigidbody playerRigidbody;
    private PlayerManager playerManagerScript;
    
    private void Awake()
    {
        if (!instance)
            instance = this;
        else if(instance != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);

        playerRigidbody = player.GetComponent<Rigidbody>();
        playerManagerScript = player.GetComponent<PlayerManager>();

    }

    public void Init()
    {
        playerManagerScript.enabled = false;
        playerManagerScript.enabled = true;
        RoadGenerator.Instance.Restart();
        player.transform.position = Vector3.up;
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
        Movement.Speed = gameSpeed;
        while (!IsGameOver())
        {
            if (lastTime + timeIncreaseSpeed < Time.time)
                IncreaseSpeed();
            yield return null;
        }
    }

    void IncreaseSpeed()
    {
        Movement.Speed -= Vector3.forward;
        lastTime = Time.time;
    }

    void GameIsOver()
    {
        playerManagerScript.enabled = false;
        Time.timeScale = 0;
        PanelAndButtonsManager.instance.GameOver();
    }
    bool IsGameOver()
    {
        playerRigidbody.AddForce(Physics.gravity * 3f, ForceMode.Acceleration);
        return playerRigidbody.velocity.y < -2 && player.transform.position.y < -15;
    }
   
}
