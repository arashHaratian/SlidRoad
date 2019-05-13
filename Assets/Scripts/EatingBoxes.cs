using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatingBoxes : MonoBehaviour
{
    private Image eatingBoxImage;
    private bool lastIsRedEated;

    public Color flashColour; /*= new Color(1, 0, 0, 200);*/
    public float fadingTime;

    private void Awake()
    {
        eatingBoxImage = GetComponent<Image>();
        lastIsRedEated = false;
    }

    private void Update()
    {
        lastIsRedEated = RedCube.isRedEated;
        if (lastIsRedEated)
            eatingBoxImage.color = flashColour;
        else
            eatingBoxImage.color = Color.Lerp(eatingBoxImage.color, Color.clear, fadingTime * Time.deltaTime);
        RedCube.isRedEated = false;
    }
}
