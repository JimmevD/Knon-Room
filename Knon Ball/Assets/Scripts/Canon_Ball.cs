using UnityEngine;

public class Canon_Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private int damage = 1;

    private void Start()
    {
        Destroy(gameObject, 2);
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.name == "Wall Y")
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            BounceBall();
        }
        else
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            BounceBall();
        }
    }

    private void BounceBall()
    {
        if (damage == 1)
        {
            sp.color = Color.yellow;
            damage = 2;
        }
    }
}
