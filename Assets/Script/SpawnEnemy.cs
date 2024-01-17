using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float SpawnTime = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(SpawnTime);
        }
    }
}
