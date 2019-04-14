using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnGUI()
    {
        GUI.TextField(new Rect(0,0,200,200), (1 / Time.deltaTime).ToString());
    }
}