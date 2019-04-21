using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowingFinger : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = Screen.width;
        slider.value = Screen.width / 2;
    }



    // Update is called once per frame
    void Update()
    {
        slider.value = PlayerManager.instance.LastPosition.x;
    }
}
