using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestZeroRot : MonoBehaviour
{
    [SerializeField] private string bug = "this script is for test and i think it will not fix";

    // Update is called once per frame
    void Update()
    {
        Quaternion q=new Quaternion(0,0,transform.parent.rotation.z,0);
        transform.parent.rotation = q; // bug lies here i think
        transform.rotation.Set(0, 0, 0,0);
    }
}
