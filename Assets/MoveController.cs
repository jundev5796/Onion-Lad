using UnityEngine;

public class MoveController : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private float xInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
    }

    private void Movement()
    {
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocityY);
    }
}
