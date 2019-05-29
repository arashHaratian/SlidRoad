using System;
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
    private float radius;
    private bool collision;

    public LayerMask blockingLayer;
    public static PlayerManager instance = null;
    public float maxMove;
    public float moveSpeed;
    private void Start()
    {
        if (!instance)
            instance = this;
        else if(instance != this)
            Destroy(this.gameObject);
        particleEffect.SetActive(false);
        wrongTabPosition = false;
        playerPosition = new Vector3(0,0,0);
        radius = transform.localScale.x / 2;
        collision = false;
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
            MoveBall(distanceOfX * (maxMove + moveSpeed) / (Screen.width / 2));
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
//                lastPosition.x = myTouch.position.x - (Screen.width / 2);
//            }
//            else //if(myTouch.phase == TouchPhase.Moved)
//            {
//                if (wrongTabPosition)
//                    return;
//                currentPosition.x = myTouch.position.x - Screen.width / 2;
//                distanceOfX = (currentPosition.x - lastPosition.x);
//                MoveBall(distanceOfX * (maxMove + moveSpeed) / (Screen.width / 2));
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
        Vector3 newPlayerPosition = playerPosition + Vector3.right * movementValue;
        if (movementValue < 0)
            LeftMove(newPlayerPosition);
        else
            RightMove(newPlayerPosition);
        SoundManager.instance.ChangeVolumeMovement(Math.Abs(movementValue));
    }

    void RightMove(Vector3 newPlayerPosition)
    {
        if (newPlayerPosition.x > maxMove)
            newPlayerPosition.x = maxMove;
        RaycastHit hit;
        if (CanMove(playerPosition, newPlayerPosition + Vector3.right * radius, out hit))
        {
            transform.position = newPlayerPosition;
            collision = false;
        }
        else
        {
            if (!collision)
            {
                SoundManager.instance.CollisionPlay(0.1f);
                collision = true;
            }
            transform.position = hit.point - Vector3.right * radius;
        }
    }

    void LeftMove(Vector3 newPlayerPosition)
    {
        if (newPlayerPosition.x < maxMove * -1)
            newPlayerPosition.x = maxMove * -1;
        RaycastHit hit;
        if (CanMove(playerPosition, newPlayerPosition - Vector3.right * radius, out hit))
            transform.position = newPlayerPosition;
        else
        {
            transform.position = hit.point + Vector3.right * radius;
            if (!collision)
            {
                SoundManager.instance.CollisionPlay(0.1f);
                collision = true;
            }
        }
    }

    bool CanMove(Vector3 start, Vector3 end, out RaycastHit hit)
    {
        return !Physics.Linecast(start, end, out hit, blockingLayer);
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
