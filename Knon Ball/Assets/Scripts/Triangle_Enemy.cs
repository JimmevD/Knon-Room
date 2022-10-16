using System.Collections.Generic;
using UnityEngine;

public class Triangle_Enemy : Enemy
{
    private Transform player;
    [SerializeField] float speed = 2f;
    [SerializeField] float growSpeed = 0.2f;

    [SerializeField] private GameObject littleTriangle;
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private ParticleSystem ExplosionParticle;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        Invoke("SpawnLittleTriangle", 1);
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > 5)
        {
            transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growSpeed;
        }
        else
        {
            Vector3 moveDir = transform.position - player.transform.position;
            transform.Translate(moveDir.normalized * speed * Time.deltaTime);
        }

        if (transform.localScale.x > 2)
        {
            Explode();
        }
    }

    private void SpawnLittleTriangle()
    {
        Instantiate(littleTriangle, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        Invoke("SpawnLittleTriangle", 2f);
    }

    private void Explode()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(littleTriangle, spawnPoints[i].transform.position, Quaternion.identity);
            Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }    
    }
}
