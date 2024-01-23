using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movelerp : MonoBehaviour
{

    [SerializeField] private float timeToTake;
    public Transform enemy;

    float m_currentTime;
    public int Hp = 3;

    public int _waypointIndex = 0;
    public int LerpMoveIndex = 0;
    WaypointManager Path;

    void Start()
    {
        m_currentTime = 0;
        Path = FindObjectOfType<WaypointManager>();
        transform.position = GameObject.FindGameObjectWithTag("Spawn").transform.position;
    }
    void Update()
    {
        MoveToWaypoint();
    }
    public void MoveToWaypoint()
    {
        int NextWaypointIndex = _waypointIndex + 1;
        m_currentTime += Time.deltaTime;
        var percentTime = m_currentTime / timeToTake;
        var newPos = BezierCurves.QuadraticLerp(Path.Waypoints[_waypointIndex].transform.position, Path.LerpObj[LerpMoveIndex].transform.position, Path.Waypoints[NextWaypointIndex].transform.position, percentTime);
        enemy.position = newPos;


        if (Vector2.Distance(Path.Waypoints[NextWaypointIndex].transform.position, enemy.position) <= .01f)
        {
            _waypointIndex++;
            LerpMoveIndex++;
            m_currentTime = 0;

            if ( _waypointIndex >= Path.Waypoints.Length-1)
            {
                
                RestartLevel PlayerHp = FindAnyObjectByType<RestartLevel>();
                PlayerHp.PlayerDamage();
                Destroy(gameObject);
            }
        }
    }
    public void TakeDamage()
    {
        Hp--;
        if (Hp == 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy Killed");
        }
    }
}
