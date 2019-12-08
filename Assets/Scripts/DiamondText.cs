using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class DiamondText: MonoBehaviour
{
    [SerializeField] private Text _diamondText;
    private int lastCountGreenCubes;
    // Start is called before the first frame update
    void Start()
    {
        _diamondText = GetComponent<Text>();
        lastCountGreenCubes= PlayerPrefs.GetInt("Green Cubes Count");
        _diamondText.text = ((int) lastCountGreenCubes).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        _diamondText.text = ((int)GreenCube.countGreenCubes).ToString();
    }
}
