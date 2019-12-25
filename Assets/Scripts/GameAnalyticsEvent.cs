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
        GameAnalytics.NewDesignEvent("Reaching Aptic Mode at score1 " + ScoreManager.score1);
        GameAnalytics.NewDesignEvent("Reaching Aptic Mode at score2 " + ScoreManager.score2);
        GameAnalytics.NewDesignEvent("Reaching Aptic Mode at score3 " + ScoreManager.score3);
        GameAnalytics.NewDesignEvent("Reaching Aptic Mode at score4 " + ScoreManager.score4);
        GameAnalytics.NewDesignEvent("Reaching Aptic Mode at score5 " + ScoreManager.score5);
        GameAnalytics.NewDesignEvent("Reaching Aptic Mode at score6 " + ScoreManager.score6);
        GameAnalytics.NewDesignEvent("Reaching Aptic Mode at score7 " + ScoreManager.score7);
        GameAnalytics.NewDesignEvent("Reaching Aptic Mode at score8 " + ScoreManager.score8);
        GameAnalytics.NewDesignEvent("Reaching Aptic Mode at score9 " + ScoreManager.score9);
        GameAnalytics.NewDesignEvent("Reaching Aptic Mode at score10 " + ScoreManager.score10);
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
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Score1", (int)ScoreManager.score1);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Score2", (int)ScoreManager.score2);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Score3", (int)ScoreManager.score3);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Score4", (int)ScoreManager.score4);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Score5", (int)ScoreManager.score5);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Score6", (int)ScoreManager.score6);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Score7", (int)ScoreManager.score7);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Score8", (int)ScoreManager.score8);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Score9", (int)ScoreManager.score9);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Score10", (int)ScoreManager.score10);
        
    }
}

/*
 * num of cubes (green ,red)
 */
