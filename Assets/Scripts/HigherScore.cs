using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HigherScore : MonoBehaviour
{
    IEnumerator scoreBounce()
    {
        ScoreManager.score += 100f;
        yield return new WaitForSeconds(3);
        
    }

    // Start is called before the first frame update
    private void Update()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale);
        foreach (Collider collider in colliders)
        {
            if(collider.CompareTag("Player"))
            {
                StartCoroutine("scoreBounce");
                print("a");
                break;
            }
        }
        StopCoroutine("scoreBounce");
    }
}
