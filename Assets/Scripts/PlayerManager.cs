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
//    public GameObject tailParticles;
    public GameObject smokeParticles;
    public GameObject fireParticles;
    public GameObject roadMapGameObject;
    public float rotateSoundVolume;

//    private Rigidbody playerRigidbody;
    private Vector2 lastPosition; 
    private Vector2 currentPosition;
    private float distanceOfX;
    private Rotation roadMap;
    private bool wrongTabPosition;
    private Vector3 resetPositionPlayer;
    private Vector3 resetRoadMapPosition;
    public static PlayerManager instance = null;
    

    private void Start()
    {
        if (!instance)
            instance = this;
        else if(instance != this)
            Destroy(this.gameObject);
        roadMap = roadMapGameObject.GetComponent<Rotation>();
        wrongTabPosition = false;
        resetPositionPlayer = new Vector3(0, 2, 14.5f);
        resetRoadMapPosition = new Vector3(0, 0, 14.5f);
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
            if (Input.mousePosition.y > Screen.height - Screen.height / 13 ||
                Input.mousePosition.y < Screen.height / 25)
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
            currentPosition = Input.mousePosition;

            distanceOfX = (currentPosition.x - lastPosition.x) / Screen.width * -1;
            roadMap.Rotate(distanceOfX);
            SoundManager.instance.ChangeVolumeMovement(Math.Abs(distanceOfX * rotateSoundVolume));
            lastPosition = currentPosition;
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
    }

    public void setActiceScoreManager(bool state)
    {
        this.GetComponent<ScoreManager>().enabled = state;
    }

    public void SetActiveFalling(bool flag)
    {
        GetComponent<Falling>().enabled = flag;
    }

    public void Reset()
    {
//        tailParticles.SetActive(true);
        fireParticles.SetActive(false);
        smokeParticles.SetActive(false);
        transform.position = resetPositionPlayer;
        roadMap.transform.position = resetRoadMapPosition;
        roadMap.transform.rotation = Quaternion.identity;
    }
}
