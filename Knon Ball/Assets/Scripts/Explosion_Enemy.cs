using UnityEngine;

public class Explosion_Enemy : Enemy
{
    private Transform player;
    [SerializeField] float speed = 2f;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
