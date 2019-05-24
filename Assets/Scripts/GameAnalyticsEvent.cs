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
}
 