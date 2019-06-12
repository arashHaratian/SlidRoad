using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public LayerMask blockingLayer;
    public float radius;
    public float gravity;
    public GameObject shade;
    public ExtraScore extraScore;

    private Vector3 newPlayerPosition;
    private bool collision;
    private Vector3 end;
    private RaycastHit hit;
    
    private void Start()
    {
        collision = false;
    }

    void Update()
    {
        newPlayerPosition = transform.position + Vector3.down * Time.deltaTime * gravity;
        if (!IsFalling())
        {

            if (!shade.activeSelf)
                shade.SetActive(true);
            if (collision)
                SoundManager.instance.PlayFallingCollision(0.3f);
            extraScore.IsCollisionStay = hit.transform.CompareTag("Edge");

            collision = false;
            transform.position = hit.point + Vector3.up * radius;
        }
        else
        {
            extraScore.IsCollisionStay =false;
            if(shade.activeSelf)
                shade.SetActive(false);
            collision = true;
            transform.position = newPlayerPosition;
        }
    }

    private bool IsFalling()
    {
        return !Physics.Linecast(transform.position + Vector3.up * 0.2f, newPlayerPosition + (Vector3.down * radius), out hit, blockingLayer);
    }
}
