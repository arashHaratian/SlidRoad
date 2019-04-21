using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTheBall : MonoBehaviour
{
    private void OnEnable()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    private void FixedUpdate()
    {
        transform.Rotate(-RoadGenerator.Instance.ActiveTiles[0].transform.position.z / 5, 0, -RoadGenerator.Instance.ActiveTiles[0].transform.position.x / 3);
    }
}
