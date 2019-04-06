using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public GameObject playerDirection;

    private Rigidbody playerRigidbody;
    private Rigidbody playerDirectionRigidbody;    
 
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerDirectionRigidbody = playerDirection.GetComponent<Rigidbody>();
    }

    void Update()
    {
        playerRigidbody.velocity = moveSpeed * playerDirection.transform.forward;
        playerDirectionRigidbody.velocity = moveSpeed * playerDirection.transform.forward;
        
        float axisRotation = Input.GetAxis("Horizontal") * rotationSpeed;
        playerDirectionRigidbody.angularVelocity = new Vector3(0, axisRotation, 0);
    }
}
