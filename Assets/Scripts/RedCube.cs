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
            Destroy(this.gameObject);
            ShowCombo.Instance.UpdateText("");
        }
    }
}
