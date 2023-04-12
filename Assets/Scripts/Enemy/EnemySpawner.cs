using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate;
    private float currentTimeSpawn;
    public int enemyTotal;
    int enemyCount;

    public GameObject EnemyList;
    void Start()
    {
        enemyCount = 0;
        currentTimeSpawn = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnRate < currentTimeSpawn && enemyCount < enemyTotal)
        {
            spawnEnemy();
            currentTimeSpawn = 0;
        }

        currentTimeSpawn += Time.deltaTime;
        if(enemyCount == enemyTotal)
        {
            Destroy(gameObject);
        }
    }


    void spawnEnemy()
    {
        GameObject spawnEnemy = Instantiate(EnemyList, transform.position, transform.rotation);
        enemyCount++;
    }
}
