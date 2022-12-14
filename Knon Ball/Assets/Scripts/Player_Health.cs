using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int health = 3;
    private int maxhealth = 3;
    SpriteRenderer sp, spChild;
    [SerializeField] private AudioSource playerHit;
    [SerializeField] private Color[] healthColor;
   
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        spChild = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().HittedPlayer();
            ChangeHealth();
        }
    }

    public void AddHealth(int amoutHp)
    {
        if (health != maxhealth)
        {
            health = health + amoutHp;
            sp.color = healthColor[health - 1];
            spChild.color = healthColor[health - 1];
        }
    }

    private void ChangeHealth()
    {
        health -= 1;

        if (health <= 0)
        {
            FindObjectOfType<UIManager>().GameOver();
        }
        else
        {
            sp.color = healthColor[health - 1];
            spChild.color = healthColor[health - 1];
        }
        playerHit.Play();
        FindObjectOfType<ScreenShake>().AddShake(0.5f);
    }
}
