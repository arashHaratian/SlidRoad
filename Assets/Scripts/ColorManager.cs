using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(MeshRenderer))]
public class ColorManager : MonoBehaviour
{
    public static ColorManager instance;

    public Image Fog;

   // public GameObject Sky;
    //public Image backGround;

    //public Color normalModeColor;
    //public Color CameraNormalModeColor;
    //public Color normalModeColorDark;

    public Color firstModeColor;
    public Color firstModeColorDark;
    public Color fogFirstModeColor;
    public Color backGroundFirstModeColor;
    public Color textureTintFirst;
    public Color secondTintFirst;
    public Color darkTextureTintFirst;
    public Color darkSecondTintFirst;


    public Color secondModeColor;
    public Color secondModeColorDark;
    public Color fogSecondModeColor;
    public Color backGroundSecondModeColor;
    public Color textureTintSecond;
    public Color secondTintSecond;
    public Color darkTextureTintSecond;
    public Color darkSecondTintSecond;

    public Color thirdModeColor;
    public Color thirdModeColorDark;
    public Color fogThirdModeColor;
    public Color backGroundThirdModeColor;
    public Color textureTintThird;
    public Color secondTintThird;
    public Color darkTextureTintThird;
    public Color darkSecondTintThird;

    public Material BlockMaterial;
    public Material DarkBlockMaterial;

    private void Awake()
    {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
    }


    public void firstStage()
    {
        Fog.color = fogFirstModeColor;
       // Sky.GetComponent<MeshRenderer>().materials[0].SetColor("Color", backGroundFirstModeColor); 
        DarkBlockMaterial.SetColor("Color_EB5D025E", firstModeColorDark);
        BlockMaterial.SetColor("Color_EB5D025E", firstModeColor);
        BlockMaterial.SetColor("Color_B1D3B990", textureTintFirst);
        BlockMaterial.SetColor("Color_23A40CCC", secondTintFirst);
        DarkBlockMaterial.SetColor("Color_B1D3B990", darkTextureTintFirst);
        DarkBlockMaterial.SetColor("Color_23A40CCC", darkSecondTintFirst);
    }

    public void secondStage()
    {
        Fog.color = fogSecondModeColor;
       // Sky.GetComponent<MeshRenderer>().materials[0].SetColor("Color", backGroundSecondModeColor);
        DarkBlockMaterial.SetColor("Color_EB5D025E", secondModeColorDark);
        BlockMaterial.SetColor("Color_EB5D025E", secondModeColor);
        BlockMaterial.SetColor("Color_B1D3B990", textureTintSecond);
        BlockMaterial.SetColor("Color_23A40CCC", secondTintSecond);
        DarkBlockMaterial.SetColor("Color_B1D3B990", darkTextureTintSecond);
        DarkBlockMaterial.SetColor("Color_23A40CCC", darkSecondTintSecond);
    }

    public void thirdStage()
    {
        Fog.color = fogThirdModeColor;
       // Sky.GetComponent<MeshRenderer>().materials[0].SetColor("Color", backGroundThirdModeColor);
        DarkBlockMaterial.SetColor("Color_EB5D025E", thirdModeColorDark);
        BlockMaterial.SetColor("Color_EB5D025E", thirdModeColor);
        BlockMaterial.SetColor("Color_B1D3B990", textureTintThird);
        BlockMaterial.SetColor("Color_23A40CCC", secondTintThird);
        DarkBlockMaterial.SetColor("Color_B1D3B990", darkTextureTintThird);
        DarkBlockMaterial.SetColor("Color_23A40CCC", darkSecondTintThird);
    }
}


//anim boxes
//particle script