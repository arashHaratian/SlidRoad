using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedCube : MonoBehaviour
{
    public static bool isRedEated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
//            PlayerManager.instance.tailParticles.SetActive(true);
            PlayerManager.instance.fireParticles.SetActive(false);
            PlayerManager.instance.smokeParticles.SetActive(false);
            ColorManager.instance.firstStage();
            isRedEated = true;
            ScoreManager.combo = 1;
            ShowCombo.Instance.UpdateText("","");
            ScoreManager.numberOfTakenGreenboxes = 0;
            PackageManager.Instance.removeRedCubes();
            SoundManager.instance.PlayGetRed(0.5f);
            Destroy(this.gameObject);
        }
    }
}
