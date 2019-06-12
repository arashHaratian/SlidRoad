using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraScoreText : MonoBehaviour
{

    public static ExtraScoreText Instance = null;
    public Text text;

    private int waitForDestroyColor;
    public Color scoreColor; 
    public Color destroyColor;
    public Coroutine lastFinishTextCo;
   
    // Start is called before the first frame update
    void Start()
    {
        if (!Instance)
            Instance = this;
        else if (Instance != this)
            Destroy(this.gameObject);

        text = GetComponent<Text>();
    }
    
    public void UpdateText(string newText)
    {
//        if (lastFinishTextCo != null)
//        {
//            StopCoroutine(lastFinishTextCo);
//            text.text = "";
//            text.color += Color.black;
//        }
        text.text = newText;
    }


    public void FinishExtraScore()
    {
        lastFinishTextCo = StartCoroutine(FinishExtraScoreCoroutine());
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
