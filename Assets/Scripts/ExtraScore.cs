using System.Collections;
using UnityEngine;

public class ExtraScore : MonoBehaviour
{
    public int waitTime_;
    
    private float extraScore_;
    private bool isCollisionStay_;
    private void Awake()
    {
       isCollisionStay_ = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        PlayerManager.instance.particleEffect.SetActive(true);
        if (other.gameObject.tag == "Player")
        {
            isCollisionStay_ = true;
            StartCoroutine(scoreBounce(waitTime_));
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
        PlayerManager.instance.particleEffect.SetActive(false);
        if (other.gameObject.tag == "Player")
        {
<<<<<<< HEAD
            isCollisionStay_ = false;
            ExtraScoreText.Instance.UpdateText(string.Empty);
            StopCoroutine("scoreBounce");
=======
            isCollisionStay_ = false;
            ScoreManager.score += extraScore_;
            ExtraScoreText.Instance.FinishExtraScore();
>>>>>>> 1eea6e21ad9e74acd30600fc91d4a5b165968ccc
        }
    }
    
    IEnumerator scoreBounce( int waiteTime)
    {
        yield return new WaitForSeconds(Time.deltaTime);
        float mult = 10;
        while (isCollisionStay_)
        {
<<<<<<< HEAD
            ScoreManager.score += (extraScore_ / CalculateTime);
            ExtraScoreText.Instance.UpdateText("+" + (extraScore_ / CalculateTime).ToString());
            yield return new WaitForSeconds(waiteTime);
            if (CalculateTime > 1)
                CalculateTime -= 1;
=======
            extraScore_ += Time.deltaTime * mult;
            ExtraScoreText.Instance.showText(extraScore_ ); 
            yield return new WaitForSeconds(Time.deltaTime);
            mult += 2;
>>>>>>> 1eea6e21ad9e74acd30600fc91d4a5b165968ccc
        }            
    }
}

