using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTheBall : MonoBehaviour
{
    public float alpha;
    public float beta;
    private void OnEnable()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    private void FixedUpdate()
    {
        transform.Rotate(-RoadGenerator.Instance.ActiveTiles[0].transform.position.z * Time.deltaTime * alpha , 0, RoadGenerator.Instance.ActiveTiles[0].transform.position.x * Time.deltaTime * beta);
    }
}