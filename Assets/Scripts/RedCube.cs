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
        transform.Rotate(Vector3.one * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRedEated = true;
            ScoreManager.combo = 1;
            ShowCombo.Instance.UpdateText("");
            ScoreManager.numberOfTakenGreenboxes = 0;
            PackageManager.Instance.numOfSkippedGreeenBoxes = 0;
            MusicManager.instance.startResetMusicSpeed();
            BackGroundColor.instance.Reset();
            BoxesStateText.Instance.UpdateText();
            Destroy(this.gameObject);
        }
    }
}
