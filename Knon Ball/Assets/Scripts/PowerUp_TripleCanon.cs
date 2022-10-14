using System.Collections;
using UnityEngine;

public class PowerUp_TripleCanon : PowerUp
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(TripleCanon());
            pickUpSound.Play();
            WaitTillEnd();
        }
    }

    private IEnumerator TripleCanon()
    {
        ps.triplecanonGO.SetActive(true);
        ps.triplecanon = true;
        yield return new WaitForSeconds(duration);
        ps.triplecanonGO.SetActive(false);
        ps.triplecanon = false;
    }

}
