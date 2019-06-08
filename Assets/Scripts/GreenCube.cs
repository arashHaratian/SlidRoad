using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GreenCube : MonoBehaviour
{
    public float speed;
    public static bool isGreenEated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
             isGreenEated = true;
            ScoreManager.numberOfTakenGreenboxes++;
            SoundManager.instance.PlayGetGreen(0.4f);
        
            if (ScoreManager.numberOfTakenGreenboxes < 4)
            {
                if (ScoreManager.numberOfTakenGreenboxes == 1)     
                    ColorManager.instance.secondStage();   
                
                    ScoreManager.combo++;
                    ShowCombo.Instance.UpdateText(ScoreManager.combo.ToString(),"x");
                    Destroy(gameObject);
                if (ScoreManager.numberOfTakenGreenboxes == 3)
                {
                    PlayerManager.instance.tailParticles.SetActive(false);
                    PlayerManager.instance.smokeParticles.SetActive(true);
                }

            }
            else
            {                          
                if (ScoreManager.numberOfTakenGreenboxes == 4)
                {
                    GameAnalyticsEvent.Instance.apticMode();                
                    ColorManager.instance.thirdStage();
                }
                if (ScoreManager.numberOfTakenGreenboxes == 7)
                {
                    PlayerManager.instance.smokeParticles.SetActive(false);
                    PlayerManager.instance.fireParticles.SetActive(true);
                }
                
                ScoreManager.score += ScoreManager.numberOfTakenGreenboxes * 50 + 50;
                ShowCombo.Instance.ApticeScore((ScoreManager.numberOfTakenGreenboxes * 50 + 50).ToString());
                Destroy(gameObject);
         }           
      }
   }
}
