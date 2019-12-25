using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GreenCube : MonoBehaviour
{
    public float speed;
    public static bool isGreenEated;
    public static int countGreenCubes;
    private Animator anim;
    private float delay = 0.4f;
    private void Start()
    {
        countGreenCubes = PlayerPrefs.GetInt("Green Cubes Count");
        anim = GetComponent<Animator>();
        anim.SetBool("isGetCube" , false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isGetCube" , true);
            isGreenEated = true;
            countGreenCubes++;
            PlayerPrefs.SetInt("Green Cubes Count", countGreenCubes);
            ScoreManager.numberOfTakenGreenboxes++;
            SoundManager.instance.PlayGetGreen(0.4f);

            if (ScoreManager.numberOfTakenGreenboxes < 4)
            {
                if (ScoreManager.numberOfTakenGreenboxes == 1)
                    ColorManager.instance.secondStage();

                ScoreManager.combo++;
                ShowCombo.Instance.UpdateText(ScoreManager.combo.ToString(), "x");
              Invoke("DestroyGreenCube", delay);
                
                if (ScoreManager.numberOfTakenGreenboxes == 3)
                {
//                    PlayerManager.instance.tailParticles.SetActive(false);
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
                if (PanelAndButtonsManager.instance.step1)
                ScoreManager.score1 += ScoreManager.numberOfTakenGreenboxes * 50 + 50;
                
                if (PanelAndButtonsManager.instance.step2)
                    ScoreManager.score2 += ScoreManager.numberOfTakenGreenboxes * 50 + 50;
                
                if (PanelAndButtonsManager.instance.step3)
                    ScoreManager.score3 += ScoreManager.numberOfTakenGreenboxes * 50 + 50;
                
                if (PanelAndButtonsManager.instance.step4)
                    ScoreManager.score4 += ScoreManager.numberOfTakenGreenboxes * 50 + 50;
                
                if (PanelAndButtonsManager.instance.step5)
                    ScoreManager.score5 += ScoreManager.numberOfTakenGreenboxes * 50 + 50;
                
                if (PanelAndButtonsManager.instance.step6)
                    ScoreManager.score6 += ScoreManager.numberOfTakenGreenboxes * 50 + 50;
                
                if (PanelAndButtonsManager.instance.step7)
                    ScoreManager.score7 += ScoreManager.numberOfTakenGreenboxes * 50 + 50;
                
                if (PanelAndButtonsManager.instance.step8)
                    ScoreManager.score8 += ScoreManager.numberOfTakenGreenboxes * 50 + 50;
                
                if (PanelAndButtonsManager.instance.step9)
                    ScoreManager.score9 += ScoreManager.numberOfTakenGreenboxes * 50 + 50;
                
                if (PanelAndButtonsManager.instance.step10)
                    ScoreManager.score10 += ScoreManager.numberOfTakenGreenboxes * 50 + 50;
                
                ShowCombo.Instance.ApticeScore((ScoreManager.numberOfTakenGreenboxes * 50 + 50).ToString());
                Destroy(gameObject);
            }
        }
    }

    private void DestroyGreenCube()
    {
        Destroy(gameObject);

    }
}
