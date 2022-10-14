using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int score;
    public ParticleSystem deadParticleSystem;
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(deadParticleSystem, transform.position, Quaternion.identity);
            FindObjectOfType<Sound_Manager>().EnemyDeadSound();
            Destroy(this.gameObject);
            FindObjectOfType<ScoreManager>().AddScore(score);
        }
    }

    public void HittedPlayer()
    {
        Instantiate(deadParticleSystem, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
