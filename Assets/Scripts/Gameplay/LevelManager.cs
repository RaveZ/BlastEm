using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //dontchange nameof Gameobject
    public GameObject EnemySpawner;
    public GameObject BossSpawner;
    public int levelCount;
    public int enemyCount;
    public int BossCount;
    public int TotalEnemy;

    //show levelUI
    public Text LevelText;
    void Start()
    {
        levelCount = 1;
        TotalEnemy = enemyCount;
        spawnPortalEnemy();
    }

    // Update is called once per frame
    void Update()
    {

        LevelText.text = levelCount.ToString();
        if (TotalEnemy <= 0)
        {
            levelCount++;
            if (levelCount % 3 == 0)
            {
                BossLevel(1);
            }
            
            if(levelCount > 10)
            {
                EnemyLevel(1);
            }
            else
            {
                EnemyLevel(2);
            }
        }
    }

    void EnemyLevel(int m_enemyCount)
    {
        enemyCount += m_enemyCount;
        TotalEnemy += enemyCount;
        spawnPortalEnemy();
    }

    void BossLevel(int m_BossCount)
    {
        BossCount += m_BossCount;
        TotalEnemy += BossCount;
        spawnPortalBoss();
    }


    void spawnPortalEnemy()
    {
        GameObject spawnPortalEnemy = Instantiate(EnemySpawner, transform.position, transform.rotation) as GameObject;
        spawnPortalEnemy.GetComponent<EnemySpawner>().enemyTotal = enemyCount;
    }

    void spawnPortalBoss()      
    {
        GameObject spawnPortalBoss = Instantiate(BossSpawner, transform.position, transform.rotation);
        spawnPortalBoss.GetComponent<EnemySpawner>().enemyTotal = BossCount;
    }
}
