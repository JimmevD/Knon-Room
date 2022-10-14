using UnityEngine;
using System.Collections;

public class Player_Shooting : MonoBehaviour
{
    [SerializeField] private Transform[] canonSpawnPoint;
    [SerializeField] private GameObject canonBall;
    
    public GameObject triplecanonGO;
    [HideInInspector] public bool triplecanon;

    [SerializeField] private GameObject canonBarrel;
    [SerializeField] private Transform[] canonAni;

    [SerializeField] private float speed = 20f;
    [SerializeField] private AudioSource shootSound;
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
                shootSound.Play();
                cooldown = Time.time + waitTime;
            }
        }      
    } 
    
    private void Shoot()
    {
        GameObject GO = Instantiate(canonBall, canonSpawnPoint[0].position, canonSpawnPoint[0].rotation);
        Rigidbody2D rb = GO.GetComponent<Rigidbody2D>();
        rb.AddForce(canonSpawnPoint[0].up * speed, ForceMode2D.Impulse);

        StartCoroutine(ShootAni());

    }

    public void TripleShoot()
    {
        for (int i = 0; i < canonSpawnPoint.Length; i++)
        {
            GameObject GO = Instantiate(canonBall, canonSpawnPoint[i].position, canonSpawnPoint[i].rotation);
            Rigidbody2D rb = GO.GetComponent<Rigidbody2D>();
            rb.AddForce(canonSpawnPoint[i].up * speed, ForceMode2D.Impulse);
        }
        StartCoroutine(ShootAni());
    }

    private IEnumerator ShootAni()
    {
        canonBarrel.transform.position = canonAni[1].position;
        yield return new WaitForSeconds(0.1f);
        canonBarrel.transform.position = canonAni[0].position;
    }
}
