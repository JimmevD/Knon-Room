using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUps;
    private float spawnPointX, spawnPointY;
    private Transform player;
    void Start()
    {
        Invoke("SpawnPowerUp", 1);
        player = GameObject.Find("Player").transform;
    }

    private void SpawnPowerUp()
    {
        spawnPointX = Random.Range(-8.5f, 8.5f);
        spawnPointY = Random.Range(-4.5f, 4.5f);

        Vector3 Spawnpoint = new Vector3(spawnPointX, spawnPointY, 0);

        if (Vector3.Distance(player.position, Spawnpoint) < 2)
        {
            SpawnPowerUp();
            return;
        }

        Instantiate(powerUps[Random.Range(0, powerUps.Length)], Spawnpoint, Quaternion.identity);
    }
}
