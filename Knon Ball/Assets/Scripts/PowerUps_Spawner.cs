using UnityEngine;

public class PowerUps_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUps;
    [SerializeField] private GameObject healthPack;
    private float spawnPointX, spawnPointY;
    private Vector3 spawnPoint;
    private Transform player;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        Invoke("SpawnPowerUp", 10);
        Invoke("CheckHealthPack", 10);
    }

    private void SpawnPowerUp()
    {
        spawnPointX = Random.Range(-8.5f, 8.5f);
        spawnPointY = Random.Range(-4.5f, 4.5f);

        spawnPoint = new Vector3(spawnPointX, spawnPointY, 0);

        if (Vector3.Distance(player.position, spawnPoint) < 2)
        {
            SpawnPowerUp();
            return;
        }

        Instantiate(powerUps[Random.Range(0, powerUps.Length)], spawnPoint, Quaternion.identity);

        CheckForCurrentPowerUp();
    }

    private void CheckForCurrentPowerUp()
    {
        if (GameObject.FindGameObjectWithTag("PowerUp") == null)
        {
            Invoke("SpawnPowerUp", 10);
        }
        else
        {
            Invoke("CheckForCurrentPowerUp", 2);
        }
    }

    private void CheckHealthPack()
    {
        if (player.gameObject.GetComponent<Player_Health>().health != 3)
        {
            spawnPointX = Random.Range(-8.5f, 8.5f);
            spawnPointY = Random.Range(-4.5f, 4.5f);

            spawnPoint = new Vector3(spawnPointX, spawnPointY, 0);

            Instantiate(healthPack, spawnPoint, Quaternion.identity);
            Invoke("CheckHealthPack", 10);
        }
        else
        {
            Invoke("CheckHealthPack", 10);
        }
    }
}
