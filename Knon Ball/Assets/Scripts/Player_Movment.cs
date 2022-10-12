using UnityEngine;

public class Player_Movment : MonoBehaviour
{
    public float movementSpeed = 4f;
    private float speedLimiter = 0.7f;
    private Rigidbody2D rb;

    private Vector2 mousePos;
    private Camera cam;


    private float horizontal, vertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= speedLimiter;
            vertical *= speedLimiter;
        }

        rb.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);

        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
    }
}
