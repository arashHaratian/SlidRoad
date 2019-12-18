using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManagerForBall : MonoBehaviour
{
    private Animator anim;
    private int rotateBall;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRotateBall" , false);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isMoveBall)
        {
            anim.SetBool("isRotateBall" , true);
        }
        else 
        {
            anim.SetBool("isRotateBall" , false);
        }
    }
}
