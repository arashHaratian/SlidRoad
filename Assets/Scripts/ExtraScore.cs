using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class ExtraScore : MonoBehaviour
{
    public int extraScore_;
    public int waitTime_;
    
    private bool isCollisionStay_;
    private int CalculateTime;
    private void Awake()
    {
       isCollisionStay_ = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            isCollisionStay_ = true;
            StartCoroutine(scoreBounce(waitTime_));
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
            isCollisionStay_ = false;
        }
    }
    
    IEnumerator scoreBounce( int waiteTime)
    {
        yield return new WaitForSeconds(waiteTime);
        CalculateTime = 3;
        while (isCollisionStay_)
        {
            ScoreManager.score += (extraScore_ / CalculateTime);
            ExtraScoreText.Instance.showText(extraScore_ / CalculateTime); 
            yield return new WaitForSeconds(waiteTime);
            if (CalculateTime > 1)
                CalculateTime -= 1;
        }            
    }
}

