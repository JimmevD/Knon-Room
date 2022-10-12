using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemy : Enemy
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
