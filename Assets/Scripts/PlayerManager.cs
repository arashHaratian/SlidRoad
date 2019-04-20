using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

//    private Rigidbody playerRigidbody;
    private Vector2 lastPosition; 
    private Vector2 currentPosition;
    private float distanceOfX;
    private GameObject roadMapGameObject;
    private Rotation roadMap;
    private float rot;

    public static PlayerManager instance = null;

    public Vector2 LastPosition
    {
        get { return lastPosition; }
    }

    private void Start()
    {
        if (!instance)
            instance = this;
        else if(instance != this)
            Destroy(this.gameObject);
        
        Application.targetFrameRate = 300;
        roadMapGameObject = GameObject.FindWithTag("Road Map");
        roadMap = roadMapGameObject.GetComponent<Rotation>();
        //        playerRigidbody = GetComponent<Rigidbody>();
        lastPosition = new Vector2(Screen.width / 2, Screen.height / 2);

    }


    private void OnDisable()
    {
        this.GetComponent<ScoreManager>().enabled = false;
    }

    private void OnEnable()
    {
        this.GetComponent<ScoreManager>().enabled = true;
        lastPosition = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    private void FixedUpdate()
    {
        Rotation();
    }
    private void Rotation()
    {
//#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if (Input.GetMouseButtonDown(0))
            currentPosition = Input.mousePosition;
        else if (Input.GetMouseButton(0))
        {
            currentPosition = Input.mousePosition;
            distanceOfX = (currentPosition.x - lastPosition.x) / Screen.width;
            float rot = distanceOfX * -1;
            roadMap.Rotate(rot, transform);
            lastPosition = currentPosition;
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
