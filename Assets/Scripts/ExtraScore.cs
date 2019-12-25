using System.Collections;
using UnityEngine;

public class ExtraScore : MonoBehaviour
{
    private float extraScore_;
    private bool isCollisionStay_;
    private bool first;
    float mult = 5;
    public bool IsCollisionStay
    {
        set { isCollisionStay_ = value; }
    }

    private void Awake()
    {
       isCollisionStay_ = false;
    }

    private void Update()
    {
        if (isCollisionStay_)
        {
            mult += 1;
            ExtraScoreText.Instance.UpdateText("+" + ((int)extraScore_).ToString());
            extraScore_ += Time.deltaTime * mult * ScoreManager.combo;
            first = true;
        }
        else if(first)
        {
            if (PanelAndButtonsManager.instance.step1)
                ScoreManager.score1 += extraScore_;
            
            if (PanelAndButtonsManager.instance.step2)
                ScoreManager.score2 += extraScore_;
            
            if (PanelAndButtonsManager.instance.step3)
                ScoreManager.score3 += extraScore_;
            
            if (PanelAndButtonsManager.instance.step4)
                ScoreManager.score4 += extraScore_;
            
            if (PanelAndButtonsManager.instance.step5)
                ScoreManager.score5 += extraScore_;
            
            if (PanelAndButtonsManager.instance.step6)
                ScoreManager.score6 += extraScore_;
            
            if (PanelAndButtonsManager.instance.step7)
                ScoreManager.score7 += extraScore_;
            
            if (PanelAndButtonsManager.instance.step8)
                ScoreManager.score8 += extraScore_;
            
            if (PanelAndButtonsManager.instance.step9)
                ScoreManager.score9 += extraScore_;
            
            if (PanelAndButtonsManager.instance.step10)
                ScoreManager.score10 += extraScore_;
            
            ExtraScoreText.Instance.FinishExtraScore();
            mult = 5;
            extraScore_ = 0;
            first = false;
        }
    }

    }
//
//    private void OnCollisionEnter(Collision other)
//    {
//        if (other.gameObject.tag == "Player")
//        {
//            isCollisionStay_ = true;
//            StartCoroutine(scoreBounce());
//            extraScore_ = 0;
//        }
//    }
//    
//    private void OnCollisionStay(Collision other)
//    {
//        if (other.gameObject.tag == "Player")
//        {
//            isCollisionStay_ = true; 
//        }
//    }
//
//    private void OnCollisionExit(Collision other)
//    {
//
//        if (other.gameObject.tag == "Player")
//        {
//            isCollisionStay_ = false;
//            StopCoroutine("scoreBounce");
//            ScoreManager.score += extraScore_;
//            ExtraScoreText.Instance.FinishExtraScore();
//        }
//    }
//    
//    IEnumerator scoreBounce()
//    {
//        yield return new WaitForSeconds(Time.deltaTime);
//        while (isCollisionStay_)
//        {
//         
//            yield return new WaitForSeconds(Time.deltaTime);
//            mult += 1;
//        }
//    }


