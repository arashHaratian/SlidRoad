using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowCombo : MonoBehaviour
{
    public static ShowCombo Instance;
    public Text comboSign;
    public Text apticCombo;
    public Text apticSign;
    private Text comboNumber;
    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else if(Instance != this)
            Destroy(this.gameObject);

        comboNumber = GetComponent<Text>();
        comboSign.text = "";
        apticSign.text = "";
        apticCombo.text = "";
    }

    public void UpdateText(string newText)
    {
        comboNumber.text = newText;
    }

    public void ApticeScore(string score)
    {
        StartCoroutine(StartApticeScore(score));
    }

    private IEnumerator StartApticeScore(string score)
    {
        apticCombo.text = score;
        apticSign.text = "+";
        yield return new WaitForSeconds(1);
        while (apticCombo.color.a >= 0)
        {
            apticCombo.color -= Color.black * Time.deltaTime;
            apticSign.color -= Color.black * Time.deltaTime;
            yield return null;
        }

        apticCombo.text = "";
        apticSign.text = "";
        apticCombo.color += Color.black;
        apticCombo.color += Color.black;    
    }

    public void UpdateSign(string newChar)
    {
        comboSign.text = newChar;
    }
}
