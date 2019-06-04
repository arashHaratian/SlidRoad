using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GreenCube : MonoBehaviour
{
    public float speed;
    public static bool isGreenEated = false;

    void Update()
    {
        transform.Rotate(Vector3.one * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isGreenEated = true;
            SoundManager.instance.PlayGetGreen(0.4f);
            if (ScoreManager.numberOfTakenGreenboxes < 2)
            {
                if (ScoreManager.numberOfTakenGreenboxes == 1)
                    ColorManager.instance.secondStage();

                ScoreManager.numberOfTakenGreenboxes++;
                ScoreManager.score += ScoreManager.numberOfTakenGreenboxes * 150;
                //ShowCombo.Instance.UpdateText("+" + ScoreManager.numberOfTakenGreenboxes * 150);
                ShowCombo.Instance.FinishExtraScore();
                Destroy(gameObject);
            }
            else
            {
                if (ScoreManager.numberOfTakenGreenboxes == 2)
                {
                    GameAnalyticsEvent.Instance.apticMode();
                    ColorManager.instance.thirdStage();
                }
                ScoreManager.numberOfTakenGreenboxes++;
                ScoreManager.combo++;
		        Destroy(this.gameObject);
           
                ShowCombo.Instance.UpdateText(ScoreManager.combo.ToString());
                gameObject.SetActive(false);
            }
        }
    }
}
