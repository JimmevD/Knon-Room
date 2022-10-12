using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [HideInInspector] public Player_Movement pm;
    public float duration = 5;

    void Start()
    {
        pm = FindObjectOfType<Player_Movement>();
    }

    public void WaitforDuration()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        Destroy(this.gameObject, duration + 0.5f);
    }

    public virtual IEnumerator powerUpAction()
    {
        Debug.Log("Standard");
        yield return new WaitForSeconds(duration);
    }
}
