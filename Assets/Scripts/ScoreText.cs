using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{ 
    private Text _scoreText;
    //private ScoreManager _scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PanelAndButtonsManager.instance.step1)
        _scoreText.text =((int)ScoreManager.score1).ToString();
        
        if (PanelAndButtonsManager.instance.step2)
            _scoreText.text =((int)ScoreManager.score2).ToString();
        
        if (PanelAndButtonsManager.instance.step3)
            _scoreText.text =((int)ScoreManager.score3).ToString();
        
        if (PanelAndButtonsManager.instance.step4)
            _scoreText.text =((int)ScoreManager.score4).ToString();
        
        if (PanelAndButtonsManager.instance.step5)
            _scoreText.text =((int)ScoreManager.score5).ToString();
        
        if (PanelAndButtonsManager.instance.step6)
            _scoreText.text =((int)ScoreManager.score6).ToString();
        
        if (PanelAndButtonsManager.instance.step7)
            _scoreText.text =((int)ScoreManager.score7).ToString();
        
        if (PanelAndButtonsManager.instance.step8)
            _scoreText.text =((int)ScoreManager.score8).ToString();
        
        if (PanelAndButtonsManager.instance.step9)
            _scoreText.text =((int)ScoreManager.score9).ToString();
        
        if (PanelAndButtonsManager.instance.step10)
            _scoreText.text =((int)ScoreManager.score10).ToString();
    }
}
