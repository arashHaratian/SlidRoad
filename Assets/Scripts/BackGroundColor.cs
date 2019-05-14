using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundColor : MonoBehaviour
{
    public static BackGroundColor instance = null;
    public float transitionTimeInSec = 2f;
    public Material roadMaterial;
    public Color roadColor;
    public Color apticRoadColor;

    private bool changingColor = false;
    private Color color1;
    [SerializeField] private Color color2;

    private void Awake()
    {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
        void Start()
    {
        ResetRoadColor();
        StartCoroutine(beginToChangeColor());
    }

    IEnumerator beginToChangeColor()
    {
        Camera cam = GetComponent<Camera>();
        color1 = Random.ColorHSV(Random.value, Random.value);
        color2 = Random.ColorHSV(Random.value, Random.value);

        while (!changingColor)
        {
            //Lerp Color and wait here until that's done
            changingColor = true;
            float counter = 0;
            while (counter < transitionTimeInSec)
            {
                counter += Time.deltaTime;

                float colorTime = counter / transitionTimeInSec;

                //Change color
                cam.backgroundColor = Color.Lerp(color1, color2, counter / transitionTimeInSec);
                //Wait for a frame
                yield return null;
            }

            changingColor = false;
            //Generate new color
            color1 = cam.backgroundColor;
            color2 = Random.ColorHSV(Random.value, Random.value, 0.2f, 0.7f, 0.3f, 1f);
        }
    }


    public void changeFaster(float deltaSec)
    {
        transitionTimeInSec -= deltaSec;
        if (transitionTimeInSec <= 0)
            transitionTimeInSec = 0.1f;
    }
    public void changeSlower(float deltaSec)
    {
        transitionTimeInSec += deltaSec;
        if (transitionTimeInSec >=15)
            transitionTimeInSec = 15f;
    }
    public void resetSpeed(float speed = 15f)
    {
        transitionTimeInSec = speed;
    }

    public void ApticRoadColor()
    {
        roadMaterial.color = apticRoadColor;
    }

    public void ResetRoadColor()
    {
        roadMaterial.color = roadColor;
    }

    public void Reset()
    {
        resetSpeed();
        ResetRoadColor();
    }
}

//    IEnumerator lerpColor(Camera targetCamera, Color fromColor, Color toColor, float duration)
//    {
//        if (changingColor)
//        {
//            yield break;
//        }
//        changingColor = true;
//        float counter = 0;

//        while (counter < duration)
//        {
//            counter += Time.deltaTime;

//            float colorTime = counter / duration;

//            //Change color
//            targetCamera.backgroundColor = Color.Lerp(fromColor, toColor, counter / duration);
//            //Wait for a frame
//            yield return null;
//        }
//        changingColor = false;
//    }
