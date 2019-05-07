using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RaisePlayerPackage : MonoBehaviour
{
    public int size;
    public float time;
    public int rotateSpeed;
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager.instance.RaiseSize(size, time);
            Destroy(this.gameObject);
        }
    }
}
