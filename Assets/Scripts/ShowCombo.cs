using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowCombo : MonoBehaviour
{
    public static ShowCombo Instance;
    public GameObject apticeText;
    public Text comboSign;
    public Text apticCombo;
    public Text apticSign;
    
    private Animation comboAnimation;
    private Animation apticAnimation;
    private Text comboNumber;
    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else if(Instance != this)
            Destroy(this.gameObject);

        comboNumber = GetComponent<Text>();
        apticAnimation = apticeText.GetComponent<Animation>();
        comboAnimation = GetComponent<Animation>();
        comboNumber.text = "";
        comboSign.text = "";
        apticSign.text = "";
        apticCombo.text = "";
    }

    public void UpdateText(string newText, string sign)
    {
        comboNumber.text = newText;
        comboSign.text = sign;
        comboAnimation.Play();
    }

    public void ApticeScore(string score)
    {
        apticCombo.text = score;
        apticSign.text = "+";
        apticAnimation.Play();
    }
}
