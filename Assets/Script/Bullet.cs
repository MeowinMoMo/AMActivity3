using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public Transform Barrel;
    Transform Target;

    private void Start()
    {
        //transform.position = Barrel.position;
        //enemy = GetComponent<DetectEnemy>();
    }

    void Update()
    {
        if (Target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, bulletSpeed * Time.deltaTime);
            float distance = Vector2.Distance(transform.position, Target.position);
            if (distance <= 0.5f)
            {
                MoveEnemy enemyHp = Target.GetComponent<MoveEnemy>();
                enemyHp.TakeDamage();
                Destroy(gameObject);
                Debug.Log("Hit");
            }
        }
        else Debug.Log("Target not in range");
    }
    public void SetTarget(Transform _target)
    {
        Target = _target;
    }
}
