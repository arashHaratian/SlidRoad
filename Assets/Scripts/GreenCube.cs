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
            if (ScoreManager.numberOfTakenGreenboxes <= 2)
            {
                ScoreManager.numberOfTakenGreenboxes++;
                ScoreManager.score += ScoreManager.numberOfTakenGreenboxes * 150;
                ShowCombo.Instance.UpdateText("+" + ScoreManager.numberOfTakenGreenboxes * 150);
                Invoke("hideString", 1f);
            }
            else
            {
                ScoreManager.combo++;
                Destroy(this.gameObject);
                ShowCombo.Instance.UpdateText("COMBO " + ScoreManager.combo + "X");
            }
        }
    }
    public void hideString()
    {
        ShowCombo.Instance.UpdateText(string.Empty);
    }
}
