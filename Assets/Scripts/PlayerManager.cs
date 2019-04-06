using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public GameObject playerDirection;

    private Rigidbody playerRigidbody;
    private Rigidbody playerDirectionRigidbody;    
    private Vector2 firstRotation; 
    private Vector2 currentTouch;
    private float distanceOfX ;
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerDirectionRigidbody = playerDirection.GetComponent<Rigidbody>();
    }   

    private void FixedUpdate()
    {
        Movement();    
        Rotation();
    }

    private void Movement()
    {
        playerRigidbody.velocity = moveSpeed * playerDirection.transform.forward;
        playerDirectionRigidbody.velocity = moveSpeed * playerDirection.transform.forward;
    }

    private void Rotation()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if (Input.GetMouseButtonDown(0))
        {
            currentTouch = Input.mousePosition;
            firstRotation = currentTouch;
        }
        else if (Input.GetMouseButtonUp(0))
            Debug.Log("Mouse Butun Down");
        else if (Input.GetMouseButton(0))
        {
            currentTouch = Input.mousePosition;
            distanceOfX = currentTouch.x - firstRotation.x;
            float rot = distanceOfX * Time.deltaTime * rotationSpeed * -1;
//            firstRotation = currentTouch;
//            playerDirection.transform.eulerAngles = new Vector3(0, playerDirection.transform.eulerAngles.y - rot, 0);
            playerDirectionRigidbody.angularVelocity = new Vector3(0, rot, 0);
        }
        
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
         if (Input.touchCount > 0)
                {
                    Touch myTouch = Input.touches[0];
                    if (myTouch.phase == TouchPhase.Began)
                    {
                        currentTouch = myTouch.position;
                        firstRotation = myTouch.position;
                    }
                    else if (myTouch.phase == TouchPhase.Moved)
                    {
                        currentTouch = myTouch.position;
                        distanceOfX = currentTouch.x - firstRotation.x;
                        float rot = distanceOfX * Time.deltaTime * rotationSpeed * -1;
                        firstRotation = currentTouch;
                        playerDirection.transform.eulerAngles = new Vector3(0, playerDirection.transform.eulerAngles.y - rot, 0);
//                        playerDirectionRigidbody.angularVelocity = new Vector3(0, rot, 0);
                    }
                }

#endif
    }
}
