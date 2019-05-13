using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GreenCube : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Rotate(Vector3.one * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PackageManager.Instance.numOfSkippedGreeenBoxes = 0;
            if (ScoreManager.numberOfTakenGreenboxes < 2)
            {
                ScoreManager.numberOfTakenGreenboxes++;
                BackGroundColor.instance.changeFaster(4f);
                MusicManager.instance.startIncreaseMusicSpeed(0.3f);
                ScoreManager.score += ScoreManager.numberOfTakenGreenboxes * 150;
                ShowCombo.Instance.UpdateText("+" + ScoreManager.numberOfTakenGreenboxes * 150);
                ShowCombo.Instance.FinishExtraScore();
                Destroy(gameObject);
            }
            else
            {
                ScoreManager.numberOfTakenGreenboxes++;
                BackGroundColor.instance.changeFaster(ScoreManager.numberOfTakenGreenboxes + 4f);
                ScoreManager.combo++;
                ShowCombo.Instance.UpdateText("COMBO " + ScoreManager.combo + "X");
                PackageManager.Instance.CubeInRoads.Remove(gameObject);
                BoxesStateText.Instance.UpdateText(PackageManager.Instance.numOfSkippedGreeenBoxes.ToString());
                gameObject.SetActive(false);
            }
        }
    }
}
