using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleDetect : MonoBehaviour
{
    public GameObject Testing;
    float distance = 2f;


    void Update()
    {
        float range = Vector2.Distance(Testing.transform.position, transform.position);
        if (range <= distance)
        {
            Debug.Log(range);
        }
    }
}
