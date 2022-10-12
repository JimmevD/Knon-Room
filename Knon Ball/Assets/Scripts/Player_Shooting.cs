using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    [SerializeField] private Transform canonSpawnPoint;
    [SerializeField] private GameObject canonBall;

    [SerializeField] private float speed = 20f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject GO = Instantiate(canonBall, canonSpawnPoint.position, canonSpawnPoint.rotation);
        Rigidbody2D rb = GO.GetComponent<Rigidbody2D>();
        rb.AddForce(canonSpawnPoint.up * speed, ForceMode2D.Impulse);
    }
}
