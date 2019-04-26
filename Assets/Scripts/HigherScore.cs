using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class HigherScore : MonoBehaviour
{
    private bool isCollisionEnter_;
    private bool isCollisionStay_;

    private void Awake()
    {
       isCollisionEnter_ = false;
       isCollisionStay_ = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            isCollisionEnter_ = true;
            isCollisionStay_ = true;
            StartCoroutine(scoreBounce());
        }
    }
    
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            isCollisionStay_ = true; 
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            isCollisionEnter_ = false;
            isCollisionStay_ = false;
            print(isCollisionStay_ + "end");
        }
    }
  
 
    IEnumerator scoreBounce()
    {
        while (isCollisionStay_)
        {
            yield return new WaitForSeconds(2);
            if (isCollisionStay_)
            {
                print("score");
                ScoreManager.bounce += 7f;  
            }
        }            
    }
}

