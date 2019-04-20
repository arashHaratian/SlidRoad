using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowingFinger : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 position;
    private void OnEnable()
    {
        position = new Vector3(0,150,0);  
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        position.x = PlayerManager.instance.LastPosition.x;
        transform.position = position;
    }
}
