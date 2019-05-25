using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject particleEffect;

//    private Rigidbody playerRigidbody;
    private Vector2 lastPosition; 
    private Vector2 currentPosition;
    private float distanceOfX;
    private bool wrongTabPosition;
    private Vector3 playerPosition;
    public static PlayerManager instance = null;
    public float maxMove;
    private void Start()
    {
        if (!instance)
            instance = this;
        else if(instance != this)
            Destroy(this.gameObject);
        particleEffect.SetActive(false);
        wrongTabPosition = false;
        playerPosition = new Vector3(0,0,0);
    }


    private void OnDisable()
    {
        this.GetComponent<ScoreManager>().enabled = false;
    }

    private void OnEnable()
    {
        this.GetComponent<ScoreManager>().enabled = true;
        if (Input.touchCount > 0)
            lastPosition = Input.touches[0].position;
    }

    private void Update()
    {
        if(!GameManager.instance.paused)
            Rotation();
        
    }

    private void Rotation()
    {
//#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.y > Screen.height - Screen.height / 13 || Input.mousePosition.y < Screen.height / 25)
            {
                wrongTabPosition = true;
                return;
            }
            wrongTabPosition = false;
            lastPosition.x = Input.mousePosition.x - Screen.width/2;
        }
        else if (Input.GetMouseButton(0))
        {
            if (wrongTabPosition)
                return;
            currentPosition.x = Input.mousePosition.x - Screen.width/2;
            distanceOfX = (currentPosition.x - lastPosition.x);
            MoveBall(distanceOfX * (maxMove + 1f) / (Screen.width / 2));
            lastPosition = currentPosition;
        }
//#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
//        if (Input.touchCount > 0)
//        {
//            Touch myTouch = Input.touches[0];
//            if (myTouch.phase == TouchPhase.Began)
//            {
//                if (myTouch.position.y > Screen.height - Screen.height / 13 || myTouch.position.y < Screen.height / 25)
//                {
//                    wrongTabPosition = true;
//                    return;
//                }
//
//                wrongTabPosition = false;
//                lastPosition = myTouch.position;
//            }
//            else //if(myTouch.phase == TouchPhase.Moved)
//            {
//                if (wrongTabPosition)
//                    return;
//                currentPosition = myTouch.position;
//                distanceOfX = (currentPosition.x - lastPosition.x) / Screen.width * -1;
//                roadMap.Rotate(distanceOfX);
//                lastPosition = currentPosition;
////                        playerDirection.transform.eulerAngles = new Vector3(0, playerDirection.transform.eulerAngles.y - rot, 0);
////                        playerDirectionRigidbody.angularVelocity = new Vector3(0, rot, 0);
//            }
//        }
//#endif
    }

    void MoveBall(float movementValue)
    {
        playerPosition = transform.position;
        transform.position += Vector3.right * movementValue;
        if (transform.position.x > maxMove)
        {
            playerPosition.x = maxMove;
            transform.position = playerPosition;
        }
        else if (transform.position.x < maxMove * -1)
        {
            playerPosition.x = maxMove * -1;
            transform.position = playerPosition;
        }
    }

    public void RaiseSize(int size, float time)
    {
        StartCoroutine(StartRaise(size, time));
    }

    private IEnumerator StartRaise(int size, float time)
    {
        while (transform.localScale.x <= size)
        {
            transform.localScale += Vector3.one * Time.deltaTime;
            yield return null;
        }

        float firstTime = Time.time;
        while (Time.time < firstTime + time)
        {
            yield return null;
        }
        
        while (transform.localScale.x >= 1)
        {
            transform.localScale -= Vector3.one * Time.deltaTime;
            yield return null;
        }
    }
}
