using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public float testSpeed =100;

    private float turnValue;
    private Rigidbody playerRigidbody;
    private string turnAxiesName = "Horizontal";

    // Start is called before the first frame update
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        turnValue = Input.GetAxis(turnAxiesName);
    }

    private void FixedUpdate()
    {
        //playerRigidbody.AddForce(turnValue * testSpeed * Time.deltaTime , 0f, 0f);
        Vector3 m = new Vector3(turnValue * testSpeed * Time.deltaTime, 0f, 0f);
        playerRigidbody.position += m;
    }
}
