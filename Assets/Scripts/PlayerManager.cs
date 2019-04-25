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
    private bool wrongTabPosition;
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
        roadMapGameObject = GameObject.FindWithTag("Road Map");
        roadMap = roadMapGameObject.GetComponent<Rotation>();
        wrongTabPosition = false;

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
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.y > Screen.height - Screen.height / 13 || Input.mousePosition.y < Screen.height / 25)
            {
                wrongTabPosition = true;
                return;
            }
            wrongTabPosition = false;
            lastPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            if (wrongTabPosition)
                return;
            currentPosition.x = Input.mousePosition.x;
            distanceOfX = (currentPosition.x - lastPosition.x) / Screen.width * -1;
            roadMap.Rotate(distanceOfX);
            lastPosition = currentPosition;
//            playerDirection.transform.eulerAngles = new Vector3(0, playerDirection.transform.eulerAngles.y - rot, 0);
//            playerDirectionRigidbody.angularVelocity = new Vector3(0, rot, 0);
        }
        
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            if (myTouch.phase == TouchPhase.Began)
            {
                if (myTouch.position.y > Screen.height - Screen.height / 13 || myTouch.position.y < Screen.height / 25)
                {
                    wrongTabPosition = true;
                    return;
                }

                wrongTabPosition = false;
                lastPosition = myTouch.position;
            }
            else //if(myTouch.phase == TouchPhase.Moved)
            {
                if (wrongTabPosition)
                    return;
                currentPosition = myTouch.position;
                distanceOfX = (currentPosition.x - lastPosition.x) / Screen.width * -1;
                roadMap.Rotate(distanceOfX);
                lastPosition = currentPosition;
//                        playerDirection.transform.eulerAngles = new Vector3(0, playerDirection.transform.eulerAngles.y - rot, 0);
//                        playerDirectionRigidbody.angularVelocity = new Vector3(0, rot, 0);
            }
        }
#endif
    }
}
