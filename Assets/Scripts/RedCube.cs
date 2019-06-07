using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedCube : MonoBehaviour
{
    public float speed;
    public static bool isRedEated = false;

    void Update()
    {
        transform.Rotate(Vector3.up * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
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
