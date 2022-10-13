using System.Collections;
using UnityEngine;

public class PowerUp_Speedboost : PowerUp
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(Speedboost());
            WaitTillEnd();
        }
    }

    private IEnumerator Speedboost()
    {
        pm.movementSpeed *= 2;
        GameObject.Find("SpeedIcon").GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(duration);
        pm.movementSpeed /= 2;
        GameObject.Find("SpeedIcon").GetComponent<SpriteRenderer>().enabled = false;
    }
}
