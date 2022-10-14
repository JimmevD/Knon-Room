using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int score;
    public ParticleSystem dead;
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(dead, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            FindObjectOfType<ScoreManager>().AddScore(score);
        }
    }

    public void HittedPlayer()
    {
            Instantiate(dead, transform.position, Quaternion.identity);
            Destroy(this.gameObject);   
    }
}
