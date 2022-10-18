using UnityEngine;

public class Canon_Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private int damage = 1;
    private float colorChanger = 1;
    [HideInInspector] public bool pierce;

    private void Start()
    {
        Destroy(gameObject, 2);
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();

        if (pierce)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            
            if (!pierce)
            {
                Destroy(this.gameObject);
            }
        }

        if (collision.gameObject.name == "Wall Y")
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            BounceBall();
        }
        else if (collision.gameObject.name == "Wall X")
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            BounceBall();
        }

        if (collision.gameObject.name == "Player")
        {
            rb.velocity = new Vector2(-rb.velocity.x, -rb.velocity.y);
            BounceBall();
        }
    }

    private void BounceBall()
    {
        colorChanger -= 0.2f;
        sp.color = new Color(1, 1, colorChanger);
        damage++;
    }
}
