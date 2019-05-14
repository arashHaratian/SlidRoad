﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class ShowCombo : MonoBehaviour
{
    public static ShowCombo Instance = null;
    private Text text;
    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else if(Instance != this)
            Destroy(this.gameObject);

        text = GetComponent<Text>();
    }

    public void UpdateText(string newText)
    {
        text.text = newText;
    }

    public void FinishExtraScore()
    {
        StartCoroutine(FinishExtraScoreCoroutine());
        StopCoroutine(FinishExtraScoreCoroutine());
    }

    private IEnumerator FinishExtraScoreCoroutine()
    {
        while (text.color.a >= 0)
        {
            text.color -= Color.black * Time.deltaTime;
            yield return null;
        }

        text.text = "";
        text.color += Color.black;
        
    }
}
