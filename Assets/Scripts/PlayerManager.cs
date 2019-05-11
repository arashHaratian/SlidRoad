using System.Collections;
using System.Collections.Generic;
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
    private Vector2 firstPosition;
    private float distanceOfX;
    private float distanceOfY;
    private GameObject roadMapGameObject;
    private Rotation roadMap;
    private bool wrongTabPosition;
    private float manualSpeed;
    
    public static PlayerManager instance = null;
    public float maxManualSpeed;
    public float minManualSpeed;
    
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
        particleEffect.SetActive(false);
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
        manualSpeed = 0;
        if (Input.touchCount > 0)
            lastPosition = Input.touches[0].position;
    }

    private void Update()
    {
        if(!GameManager.instance.paused)
            Rotation();
        
    }

    IEnumerator ResetManualSpeed()
    {
        if(manualSpeed > 0)
            while (manualSpeed >= 0)
            {
                manualSpeed -= Time.deltaTime * 8;
                yield return null;
            }
        else
            while (manualSpeed <= 0)
            {
                manualSpeed += Time.deltaTime * 8;
                yield return null;
            }

        manualSpeed = 0;
    }

    private void Rotation()
    {
        Movement.DeltaSpeed = manualSpeed * -1;
        CameraFollow.Instance.RotateAround(transform, manualSpeed * -1);
//#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.y > Screen.height - Screen.height / 13 || Input.mousePosition.y < Screen.height / 25)
            {
                wrongTabPosition = true;
                return;
            }
            wrongTabPosition = false;
            lastPosition = Input.mousePosition;
            firstPosition = lastPosition;
        }
        else if (Input.GetMouseButton(0))
        {
            if (wrongTabPosition)
                return;
            currentPosition = Input.mousePosition;
            
            distanceOfX = (currentPosition.x - lastPosition.x) / Screen.width * -1;
            roadMap.Rotate(distanceOfX);
            lastPosition = currentPosition;

            distanceOfY = (currentPosition.y - firstPosition.y) / Screen.height;
            manualSpeed = distanceOfY * Movement.Speed.z * 2;
            if (manualSpeed > maxManualSpeed)
                manualSpeed = maxManualSpeed;
            else if (manualSpeed < minManualSpeed)
                manualSpeed = minManualSpeed;
            print(manualSpeed);
//              playerDirection.transform.eulerAngles = new Vector3(0, playerDirection.transform.eulerAngles.y - rot, 0);
//              playerDirectionRigidbody.angularVelocity = new Vector3(0, rot, 0);
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                StartCoroutine(ResetManualSpeed());
            }
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
