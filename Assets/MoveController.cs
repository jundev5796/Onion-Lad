using UnityEngine;

public class MoveController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private float xInput;

    [Header("Collision Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded;

    private bool facingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationControllers();
        CollisionChecks();
        FlipController();

        xInput = Input.GetAxisRaw("Horizontal");

        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

    }

    private void AnimationControllers()
    {
        anim.SetFloat("xVelocity", rb.linearVelocityX);
        anim.SetFloat("yVelocity", rb.linearVelocityY);
        anim.SetBool("isGrounded", isGrounded);
    }


    private void Jump()
    {
        if (isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
    }

    private void Movement()
    {
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocityY);
    }

    private void FlipController()
    {
        if (rb.linearVelocityX < 0 && facingRight)
            Flip();
        else if (rb.linearVelocityX > 0 && !facingRight)
            Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void CollisionChecks() 
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
