using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorfulText : MonoBehaviour
{
    public float transitionTimeInSec = 2f;
    private bool changingColor = false;

    private Color color1;
    [SerializeField] private Color color2;

    void Start()
    {
        StartCoroutine(beginToChangeColor());
    }

    IEnumerator beginToChangeColor()
    {
        Text text = GetComponent<Text>();
        color1 = Random.ColorHSV(Random.value, Random.value);
        color2 = Random.ColorHSV(Random.value, Random.value);

        while (true)
        {
            //Lerp Color and wait here until that's done
            yield return lerpColor(text, color1, color2, transitionTimeInSec);

            //Generate new color
            color1 = text.color;
            color2 = Random.ColorHSV(Random.value, Random.value, 0.2f, 0.7f, 0.3f, 1f);
        }
    }

    IEnumerator lerpColor(Text targetText, Color fromColor, Color toColor, float duration)
    {
        if (changingColor)
        {
            yield break;
        }
        changingColor = true;
        float counter = 0;

        while (counter < duration)
        {
            counter += 0.07f;

            float colorTime = counter / duration;

            //Change color
            targetText.color = Color.Lerp(fromColor, toColor, counter / duration);
            //Wait for a frame
            yield return null;
        }
        changingColor = false;
    }
}
