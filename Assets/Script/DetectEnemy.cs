using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    public Transform TurretHeadPoint;
    public Transform TurrelBarrel;
    public GameObject bulletPrefab;
    public int DetectRange = 5;
    public bool hasDetected;
    public float TowerRotateSpeed = 150f;
    public float firingRate = 2f;
    public float FireTime = 0.0f;
    Transform Target;
    void Update()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in Enemies)
        {
            Target = Enemy.transform;
            float Distance = Vector2.Distance(Enemy.transform.position, transform.position);
            if (Distance <= DetectRange)
            {
                if (!hasDetected)
                {
                    RotateTarget(Enemy);
                    //FireEnemy(Enemy);
                    hasDetected = true;
                }
                hasDetected = false;
            }
        }
    }
    public void RotateTarget(GameObject enemy)
    {
        float angle = Mathf.Atan2(enemy.transform.position.y - transform.position.y,
                                  enemy.transform.position.x - transform.position.x) * Mathf.Rad2Deg + -90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        TurretHeadPoint.rotation = Quaternion.Slerp(TurretHeadPoint.rotation, targetRotation, TowerRotateSpeed * Time.deltaTime);
        FireEnemy(enemy);
    }

    public void FireEnemy(GameObject enemy)
    {
        if (Time.time >= FireTime)
        {
            GameObject cloneBullet_GO = Instantiate(bulletPrefab, TurrelBarrel.position, Quaternion.identity);
            Bullet bulletScript = cloneBullet_GO.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.SetTarget(Target);
            }
            FireTime = Time.time + 1f / firingRate;
        }
    }
        private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, DetectRange);
    }
}
