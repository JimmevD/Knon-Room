using UnityEngine;

public class Canon_Enemy : Enemy
{
    private Transform player;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource shootSound;

    private float randomShootTime;
    [SerializeField] private Transform shootPoint;
    [SerializeField] GameObject enemyBullet;
    [SerializeField] private float speed;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        Invoke("Shoot", Random.Range(0.5f, 2f));
    }

    void Update()
    {
        Vector2 lookDirection = new Vector2(player.position.x, player.position.y)- rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
    }

    private void Shoot()
    {
        GameObject GO = Instantiate(enemyBullet, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = GO.GetComponent<Rigidbody2D>();
        rb.AddForce(shootPoint.up * speed, ForceMode2D.Impulse);
        shootSound.Play();

        randomShootTime = Random.Range(2, 6);
        Invoke("Shoot", randomShootTime);
    }
}
