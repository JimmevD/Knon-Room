using System.Collections;
using UnityEngine;

public class PowerUp_Speedboost : PowerUp
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(powerUpAction());
            WaitforDuration();
        }
    }

    public override IEnumerator powerUpAction()
    {
        pm.movementSpeed *= 2;
        pm.speedLimiter *= 2;
        yield return new WaitForSeconds(duration);
        pm.movementSpeed /= 2;
        pm.speedLimiter /= 2;
    }
}
