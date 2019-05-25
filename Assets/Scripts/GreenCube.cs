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
            if (ScoreManager.numberOfTakenGreenboxes < 2)
            {
                ScoreManager.numberOfTakenGreenboxes++;
                MusicManager.instance.startIncreaseMusicSpeed(0.3f);
                ScoreManager.score += ScoreManager.numberOfTakenGreenboxes * 150;
                ShowCombo.Instance.UpdateText("+" + ScoreManager.numberOfTakenGreenboxes * 150);
                ShowCombo.Instance.FinishExtraScore();
                Destroy(gameObject);
            }
            else
            {
                if (ScoreManager.numberOfTakenGreenboxes == 2)
                {
                    MusicManager.instance.startIncreaseMusicSpeed(0.6f);
                    
                }
                    
                ScoreManager.numberOfTakenGreenboxes++;
                ScoreManager.combo++;
		 Destroy(this.gameObject);
           
                ShowCombo.Instance.UpdateText("COMBO " + ScoreManager.combo + "X");
                gameObject.SetActive(false);
            }
        }
    }
}
