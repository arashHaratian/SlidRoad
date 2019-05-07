using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraScoreText : MonoBehaviour
{
    
    private static ExtraScoreText _instance;
    public static  ExtraScoreText Instance
    {
        get
        {
            return _instance;
        }
    }
    
    private Text text;

    public Text Text
    {
        get { return text; }
        set { text = value; }
    }

    private int waitForDestroyColor;
    public Color scoreColor; 
    public Color destroyColor;
   
    // Start is called before the first frame update
    void Start()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;

        text = GetComponent<Text>();
    }

    // Update is called once per frame
    public void showText(float instanceOfExtraScore)
    {
            text.text = "+" + (int)instanceOfExtraScore; 
            text.color = scoreColor;
//            StartCoroutine("ChangeColor");
    }

    public void FinishExtraScore()
    {
        StartCoroutine(FinishExtraScoreCoroutine());
    }
    private IEnumerator FinishExtraScoreCoroutine()
    {;
        while (text.color.a >= 0)
        {
            text.color -= Color.black * Time.deltaTime; 
            yield return null;
        }

        text.text = "";
        text.color += Color.black;
    }

}
