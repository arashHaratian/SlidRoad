using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraScoreText : MonoBehaviour
{

    public static ExtraScoreText Instance = null;
    private Text text;
    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else if (Instance != this)
            Destroy(this.gameObject);

        text = GetComponent<Text>();
    }

    public void UpdateText(string newText)
    {
        text.text = newText;
    }
}
