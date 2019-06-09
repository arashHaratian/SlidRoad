using System.Collections;
using UnityEngine;

public class ExtraScore : MonoBehaviour
{
    private float extraScore_;
    private bool isCollisionStay_;
    private void Awake()
    {
       isCollisionStay_ = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            isCollisionStay_ = true;
            StartCoroutine(scoreBounce());
            extraScore_ = 0;
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
            StopCoroutine("scoreBounce");
            ScoreManager.score += extraScore_;
            ExtraScoreText.Instance.FinishExtraScore();
        }
    }
    
    IEnumerator scoreBounce()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        float mult = 5;
        while (isCollisionStay_)
        {
            ExtraScoreText.Instance.UpdateText("+" + ((int)extraScore_).ToString());
            extraScore_ += Time.deltaTime * mult * ScoreManager.combo;
            yield return new WaitForSeconds(Time.deltaTime);
            mult += 1;
        }
    }
}

