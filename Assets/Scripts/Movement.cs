using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private static Vector3 speed;
    private Rigidbody rb;
    public static Vector3 Speed
    {
        set { speed = value; }
        get { return speed; }
    }

    private void Update()
    {
        transform.position = transform.position +( speed * Time.deltaTime);

    }
}
