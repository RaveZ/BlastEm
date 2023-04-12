
using UnityEngine;
using UnityEngine.UI;
public class EnemyTarget : MonoBehaviour
{
    public float health;
    private float maxHealth;
    public HealthSlider healthSlider;
    public GameObject levelManager;
    public int enemyScore;
    int currentScore;

    //Score
    public Text ScoreText;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager");
        maxHealth = health;
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }   

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthSlider.reduceHealth(damageAmount / maxHealth);
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        currentScore = int.Parse(ScoreText.text);
        currentScore += enemyScore;
        ScoreText.text = currentScore.ToString();
        levelManager.GetComponent<LevelManager>().TotalEnemy--;
        Destroy(gameObject);
    }
}
