using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatingBoxes : MonoBehaviour
{
    private Image eatingBoxImage;
    private bool lastIsRedEated;
    private bool lastIsGreenEated;

    public Color flashColourForRedBox; /*= new Color(1, 0, 0, 200);*/
    public Color flashColourForGreenBox;
    public float fadingTime;

    private void Awake()
    {
        eatingBoxImage = GetComponent<Image>();
        lastIsRedEated = false;
    }

    private void Update()
    {
        lastIsRedEated = RedCube.isRedEated;
        lastIsGreenEated = GreenCube.isGreenEated;
        if (lastIsRedEated)
            eatingBoxImage.color = flashColourForRedBox;
        else
            eatingBoxImage.color = Color.Lerp(eatingBoxImage.color, Color.clear, fadingTime * Time.deltaTime);

        if (lastIsGreenEated)
            eatingBoxImage.color = flashColourForGreenBox;
        else
            eatingBoxImage.color = Color.Lerp(eatingBoxImage.color, Color.clear, fadingTime * Time.deltaTime);
        RedCube.isRedEated = GreenCube.isGreenEated = false;
    }
}
