using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    [SerializeField] private Transform canonSpawnPoint;
    [SerializeField] private GameObject canonBall;

    [SerializeField] private float speed = 20f;

    private float cooldown, waitTime = 0.5f;

    void Update()
    {
        if (Time.time > cooldown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                cooldown = Time.time + waitTime;
            }
        }      
    } 
    
    private void Shoot()
    {
        GameObject GO = Instantiate(canonBall, canonSpawnPoint.position, canonSpawnPoint.rotation);
        Rigidbody2D rb = GO.GetComponent<Rigidbody2D>();
        rb.AddForce(canonSpawnPoint.up * speed, ForceMode2D.Impulse);
    }
}
