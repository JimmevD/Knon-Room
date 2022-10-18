using System.Collections;
using UnityEngine;

public class PowerUp_Pierce : PowerUp
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(ActivePierce());
            pickUpSound.Play();
            WaitTillEnd();
        }
    }

    IEnumerator ActivePierce()
    {
        ps.pierce = true;
        GameObject.Find("PierceIcon").GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(duration);
        GameObject.Find("PierceIcon").GetComponent<SpriteRenderer>().enabled = false;
        ps.pierce = false;
    }
}

