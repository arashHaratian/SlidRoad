﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxesStateText : MonoBehaviour
{
    public static BoxesStateText Instance = null;
    Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else if (Instance != this)
            Destroy(this.gameObject);

        text = GetComponent<Text>();
    }

    public void UpdateText()
    {
        if (PackageManager.Instance.numOfSkippedGreeenBoxes == 0)
            text.text = "";
        else
            text.text = PackageManager.Instance.numOfSkippedGreeenBoxes + "/2";
    }

    public void ResetBoxesState()
    {
        text.text = "";
    }

    public void FinishBoxesState()
    {
        StartCoroutine(FinishBoxesStateCoroutine());
        StopCoroutine(FinishBoxesStateCoroutine());
    }

    private IEnumerator FinishBoxesStateCoroutine()
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