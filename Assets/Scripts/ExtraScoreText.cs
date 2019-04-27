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
    public void showText(int instanceOfExtraScore)
    {

            text.text = "+" + instanceOfExtraScore; 
            text.color = scoreColor;
            StartCoroutine("ChangeColor");
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        text.color = destroyColor;
    }

}
