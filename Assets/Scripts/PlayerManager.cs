using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

//    private Rigidbody playerRigidbody;
    private Vector2 firstPosition; 
    private Vector2 currentPosition;
    private float distanceOfX;
    private GameObject roadMapGameObject;
    private Rotation roadMap;
    private float rot;
    private void Start()
    {
        Application.targetFrameRate = 300;
        roadMapGameObject = GameObject.FindWithTag("Road Map");
        roadMap = roadMapGameObject.GetComponent<Rotation>();
        if (Input.touchCount > 0)
            firstPosition = Input.touches[0].position;
//        playerRigidbody = GetComponent<Rigidbody>();
    }
    

    private void OnDisable()
    {
        this.GetComponent<ScoreManager>().enabled = false;
    }

    private void OnEnable()
    {
        this.GetComponent<ScoreManager>().enabled = true;
    }

    private void Update()
    {
        Rotation();
    }
    private void Rotation()
    {
//#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if (Input.GetMouseButtonDown(0))
        {
            currentPosition = Input.mousePosition;
            firstPosition = currentPosition;
        }
        else if (Input.GetMouseButtonUp(0))
            Debug.Log("Mouse Butun Down");
        else if (Input.GetMouseButton(0))
        {
            currentPosition= Input.mousePosition;
            distanceOfX = currentPosition.x - firstPosition.x;
            float rot = distanceOfX * Time.deltaTime * -1;
            roadMap.Rotate(rot, transform);
//            firstRotation = currentTouch;
//            playerDirection.transform.eulerAngles = new Vector3(0, playerDirection.transform.eulerAngles.y - rot, 0);
//            playerDirectionRigidbody.angularVelocity = new Vector3(0, rot, 0);
        }
        
//#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
//        if (Input.touchCount > 0)
//        {
//            Touch myTouch = Input.touches[0];
//            if (myTouch.phase == TouchPhase.Began)
//            {
//                currentPosition = myTouch.position;
//                firstPosition = myTouch.position;
//            }
//            else //if (myTouch.phase == TouchPhase.Moved)
//            {
//                currentPosition = myTouch.position;
//                distanceOfX = currentPosition.x - firstPosition.x;
//                rot = distanceOfX * Time.deltaTime * -1;
////                firstPosition = currentPosition;
//                roadMap.Rotate(rot, transform);
////                        playerDirection.transform.eulerAngles = new Vector3(0, playerDirection.transform.eulerAngles.y - rot, 0);
////                        playerDirectionRigidbody.angularVelocity = new Vector3(0, rot, 0);
//            }
//        }
//#endif
    }
}
