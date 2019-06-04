using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandAnimation : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value == 0)
            InvokeRepeating("moveToRight", 0, Time.fixedDeltaTime);

        //if (slider.value == 100)

    }

    private void moveToRight()
    {
        slider.value += Time.fixedDeltaTime * 100;
    }
}
