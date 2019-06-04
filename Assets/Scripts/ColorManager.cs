using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshRenderer))]
public class ColorManager : MonoBehaviour
{
    public static ColorManager instance;

    public Image Fog;
    public Image backGround;

    //public Color normalModeColor;
    //public Color CameraNormalModeColor;
    //public Color normalModeColorDark;

    public Color firstModeColor;
    public Color fogFirstModeColor;
    public Color backGroundFirstModeColor;
    public Color firstModeColorDark;

    public Color secondModeColor;
    public Color fogSecondModeColor;
    public Color backGroundSecondModeColor;
    public Color secondModeColorDark;

    public Color thirdModeColor;
    public Color fogThirdModeColor;
    public Color backGroundThirdModeColor;
    public Color thirdModeColorDark;

    public Material BlockMaterial;
    public Material DarkBlockMaterial;

    [SerializeField]
    private Color privateBlockMaterialColor;
    private Color privateDarkBlockMaterialColor;

    private void Awake()
    {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        privateBlockMaterialColor = BlockMaterial.GetColor("Color_EB5D025E");
        privateDarkBlockMaterialColor = DarkBlockMaterial.GetColor("Color_EB5D025E");
    }
    //public void normalStage()
    //{
    //    mainCamera.backgroundColor = CameraNormalModeColor;
    //    BlockMaterialColor = normalModeColor;
    //    DarkBlockMaterialColor = normalModeColorDark;
    //}


    public void firstStage()
    {
        Fog.color = fogFirstModeColor;
        backGround.color = backGroundFirstModeColor;
        privateBlockMaterialColor = firstModeColor;
        privateDarkBlockMaterialColor = firstModeColorDark;
    }

    public void secondStage()
    {
        Fog.color = fogSecondModeColor;
        backGround.color = backGroundSecondModeColor;
        privateBlockMaterialColor = secondModeColor;
        privateDarkBlockMaterialColor = secondModeColorDark;
    }

    public void thirdStage()
    {
        Fog.color = fogThirdModeColor;
        backGround.color = backGroundThirdModeColor;
        privateBlockMaterialColor = thirdModeColor;
        privateDarkBlockMaterialColor = thirdModeColorDark;
    }
}



//reset Anime or slider script
//set anchor of ui
//2first extra score
//delete quit code
