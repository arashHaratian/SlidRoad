using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreFoeEachLevel : MonoBehaviour
{
    [SerializeField] private Text _highScoreText;
    public int level;


    private void Start()
    {
        _highScoreText.text = ((int)PlayerPrefs.GetFloat("highScore"+level)).ToString(CultureInfo.InvariantCulture);
    }
}
