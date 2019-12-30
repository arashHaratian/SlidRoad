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
        anim.SetBool("isWin", false);

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

        if (GameManager.instance.iswinTheGame )
        {
            anim.SetBool("isWin", true);
            PlayerManager.instance.smokeParticles.SetActive(false);
            PlayerManager.instance.fireParticles.SetActive(false);
            Invoke("SetActiveBall", 2);
        }

        else
        {
            anim.SetBool("isWin", false);
        }
    }

    private void SetActiveBall()
    {
        if (GameManager.instance.iswinTheGame)
        {
            gameObject.SetActive(false);
        }
      
    }
    
}
