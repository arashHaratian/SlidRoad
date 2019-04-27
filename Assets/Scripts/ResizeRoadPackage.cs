using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeRoadPackage : MonoBehaviour
{
    public GameObject roadMap;

    private void OnEnable()
    {
        roadMap.transform.localScale = new Vector3(roadMap.transform.lossyScale.x / 2, roadMap.transform.lossyScale.y, roadMap.transform.lossyScale.z/2);
    }

    private void Update()
    {
        //Physics.OverlapBox()
    }
}
