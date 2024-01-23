using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleLerp : MonoBehaviour
{
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private Transform point3;

    [SerializeField] private Transform objectToMove;

    [SerializeField] private float timeToTake;

    float m_currentTime;
    // Start is called before the first frame update
    void Start()
    {
        m_currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
     /*   if (point3 == null 
            || point2 == null 
            || point1 == null 
            || objectToMove == null) return;*/

        m_currentTime += Time.deltaTime;
        var percentTime = m_currentTime / timeToTake;
        var newPos = BezierCurves.QuadraticLerp(point1.position, point2.position, point3.position, percentTime);
        objectToMove.position = newPos;
    }
}
