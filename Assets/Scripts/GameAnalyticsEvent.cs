using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
public class GameAnalyticsEvent : MonoBehaviour
{
    public static GameAnalyticsEvent Instance;
    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else if (Instance != this)
            Destroy(this.gameObject);
        GameAnalytics.Initialize();
    }


    public void apticMode()
    {
        GameAnalytics.NewDesignEvent("Reaching Aptic Mode at score " + ScoreManager.score);
    }


    public void getLastRoadBeforeExit(string RoadName)
    {
        GameAnalytics.NewDesignEvent("Quit the game in " + RoadName + " Road");
    }


    public void getGameOverRoad (string RoadName)
    {
        GameAnalytics.NewDesignEvent("GameOver in " + RoadName + " Road");
    }


    public void getScore()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Score", (int)ScoreManager.score);
    }
}

/*
 * num of cubes (green ,red)
 */
