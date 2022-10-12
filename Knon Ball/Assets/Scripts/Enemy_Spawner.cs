using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField] GameObject explosionEnemy, CanonEnemy;
    private float spawnPointX, spawnPointY, waitTime;
    private Transform player;
    private float increaseDifficulty;
   
    void Start()
    {
        Invoke("SpawnEnemy", 1);
        player = GameObject.Find("Player").transform;
    }

    private void SpawnEnemy()
    {
        spawnPointX = Random.Range(-8.5f, 8.5f);
        spawnPointY = Random.Range(-4.5f, 4.5f);

        Vector3 Spawnpoint = new Vector3(spawnPointX, spawnPointY, 0);

        if (Vector3.Distance(player.position, Spawnpoint) < 2)
        {
            SpawnEnemy();
            return;
        }

        if (Random.Range(0, 100) < 20)
        {
            Instantiate(CanonEnemy, Spawnpoint, Quaternion.identity);
        }
        else
        {
            Instantiate(explosionEnemy, Spawnpoint, Quaternion.identity);
        }


        waitTime = Random.Range(1 - increaseDifficulty, 2 - increaseDifficulty);
        Invoke("SpawnEnemy", waitTime);
        
        if (increaseDifficulty !> 0.5f)
        increaseDifficulty += 0.01f;
    }
}