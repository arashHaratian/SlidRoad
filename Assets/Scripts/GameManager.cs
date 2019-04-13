using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject player;

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
        
        playerManagerScript.enabled = true;
        //road Manager init
        Time.timeScale = 1;
        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop()
    { Time.timeScale = 1;
        yield return StartCoroutine(RoundStarting());
        GameIsOver();        
    }

    IEnumerator RoundStarting()
    {
        while (!IsGameOver())
            yield return null;
    }

    void GameIsOver()
    {
        playerManagerScript.enabled = false;
        Time.timeScale = 0;
        //road manager stop
        PanelAndButtonsManager.instance.GameOver();
    }
    bool IsGameOver()
    {
        return playerRigidbody.velocity.y < -2 && player.transform.position.y < 0;
    }
   
}
