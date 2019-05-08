using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraScoreText : MonoBehaviour
{

    public static ExtraScoreText Instance = null;
    private Text text;
<<<<<<< HEAD
    private void Awake()
=======

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
>>>>>>> 1eea6e21ad9e74acd30600fc91d4a5b165968ccc
    {
        if (!Instance)
            Instance = this;
        else if (Instance != this)
            Destroy(this.gameObject);

        text = GetComponent<Text>();
    }

<<<<<<< HEAD
    public void UpdateText(string newText)
    {
        text.text = newText;
    }
=======
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

>>>>>>> 1eea6e21ad9e74acd30600fc91d4a5b165968ccc
}
