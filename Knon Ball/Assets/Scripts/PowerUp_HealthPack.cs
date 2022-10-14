using UnityEngine;

public class PowerUp_HealthPack : PowerUp
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ph.AddHealth(1);
            pickUpSound.Play();
            WaitTillEnd();
        }
    }
}
