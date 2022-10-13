using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    [SerializeField] private Transform[] canonSpawnPoint;
    [SerializeField] private GameObject canonBall;
    
    public GameObject triplecanonGO;
    [HideInInspector] public bool triplecanon;

    [SerializeField] private float speed = 20f;

    private float cooldown, waitTime = 0.5f;


    void Update()
    {
        if (Time.time > cooldown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!triplecanon)
                {
                    Shoot();
                }
                else
                {
                    TripleShoot();
                }
                cooldown = Time.time + waitTime;
            }
        }      
    } 
    
    private void Shoot()
    {
        GameObject GO = Instantiate(canonBall, canonSpawnPoint[0].position, canonSpawnPoint[0].rotation);
        Rigidbody2D rb = GO.GetComponent<Rigidbody2D>();
        rb.AddForce(canonSpawnPoint[0].up * speed, ForceMode2D.Impulse);
    }

    public void TripleShoot()
    {
        for (int i = 0; i < canonSpawnPoint.Length; i++)
        {
            GameObject GO = Instantiate(canonBall, canonSpawnPoint[i].position, canonSpawnPoint[i].rotation);
            Rigidbody2D rb = GO.GetComponent<Rigidbody2D>();
            rb.AddForce(canonSpawnPoint[i].up * speed, ForceMode2D.Impulse);
        }
    }
}
