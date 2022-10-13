using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [HideInInspector] public Player_Movement pm;
    [HideInInspector] public Player_Health ph;
    [HideInInspector] public Player_Shooting ps;
    public float duration = 5;

    void Start()
    {
        pm = FindObjectOfType<Player_Movement>();
        ph = FindObjectOfType<Player_Health>();
        ps = FindObjectOfType<Player_Shooting>();
    }

    public void WaitTillEnd()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        Destroy(gameObject, duration + 0.01f);
    }
}
