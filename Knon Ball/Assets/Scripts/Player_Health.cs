using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    private int health = 3;
    SpriteRenderer sp, spChild;
    [SerializeField] private Color[] healthColor;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        spChild = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            print("test");
        }

            if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(1);
            print("Gothit");
            health -= 1;

            if (health <= 0)
            {
                //Gameover();
                Debug.Log("Dead");
            }

            sp.color = healthColor[health - 1];
            spChild.color = healthColor[health - 1];

        }
    }
}
