using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedCube : MonoBehaviour
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
            ScoreManager.combo = 1;
            ShowCombo.Instance.UpdateText("");
            ScoreManager.numberOfTakenGreenboxes = 0;
            MusicManager.instance.startResetMusicSpeed();
            BackGroundColor.instance.resetSpeed();
            Destroy(this.gameObject);
        }
    }
}
