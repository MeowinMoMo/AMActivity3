using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public int _enemySpeed = 3;
    public int Hp = 3;
    
    public int _waypointIndex = 0;
    WaypointManager Path;

    void Start()
    {
        Path = FindObjectOfType<WaypointManager>();
        transform.position = GameObject.FindGameObjectWithTag("Spawn").transform.position;
    }
    void Update()
    {
        MoveToWaypoint();
    }
    public void MoveToWaypoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, Path.Waypoints[_waypointIndex], _enemySpeed * Time.deltaTime);
        if (Vector2.Distance(Path.Waypoints[_waypointIndex], transform.position) <= 0.05f)
        {
            _waypointIndex++;
            if (_waypointIndex == Path.Waypoints.Length)
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
