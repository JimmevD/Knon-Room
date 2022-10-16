using UnityEngine;

public class Canon_Ball : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        Destroy(gameObject, 2);
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(1);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.name == "Wall Y")
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
    }
}
