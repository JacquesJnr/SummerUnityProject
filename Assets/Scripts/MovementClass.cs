using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MovementClass : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rb2d;
    private GameObject Player;
    public Vector2 directionForce;
    public float playerSpeed = 1f;
    public float jumpForce = 300f;
    private const float airSpeed = 200f;
    public float climbSpeed = 100f;

    public bool facingRight;
    public bool grounded;
    public Transform groundCheck;
    private float checkRadius = 0.05f;
    public LayerMask whatIsGround;
    public LayerMask whatIsVines;
    public LayerMask whatIsLava;

    public bool touchingVineWall; 
    public bool touchingWallRight;
    public bool touchingWallLeft;
    public bool inLava;
    public bool lavaImmune;
    public float wallCheckRadius;
    private float vineCheckRadius = 0.1f;
    public Transform RightWallCheck;
    public Transform LeftWallCheck;
    public Transform VineWallCheck;
    public Transform lavaFloorCheck;

    private int maxJumps = 1;
    public int maxJumpValue;
    public bool canFloat;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        maxJumps = maxJumpValue;
        directionForce.x = 7f;

        if (rb2d.velocity.x > 0)
        {
            facingRight = true;
        }
        else
        {
            facingRight = false;
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        inLava = Physics2D.OverlapCircle(lavaFloorCheck.position, checkRadius, whatIsLava);
        touchingWallRight = Physics2D.OverlapCircle(RightWallCheck.position, wallCheckRadius, whatIsGround);
        touchingWallLeft = Physics2D.OverlapCircle(LeftWallCheck.position, wallCheckRadius, whatIsGround);
        touchingVineWall = Physics2D.OverlapCircle(VineWallCheck.position, vineCheckRadius, whatIsVines);

        if (grounded) // Resets the gravity
        {
            rb2d.gravityScale = 2;
        }

        if (!touchingWallRight || !touchingWallLeft) // Player will not move forward while they are touching a wall
        {
            transform.Translate(directionForce * playerSpeed * Time.deltaTime);
        }

        if(rb2d.velocity.y < 0 && maxJumps == 0 && !touchingWallLeft && !touchingWallRight) // Checks if the player is falling and has no jumps
        {
            canFloat = true;
        }
        else
        {
            canFloat = false;
        }
    }

    void Update()
    {
       
        if (grounded)
        {
            maxJumps = maxJumpValue;
        }

        if (Input.GetButtonDown("Jump") && maxJumps >=1)
        {
            maxJumps--;
            Jump();
        }

        if (Input.GetButton("Jump") && canFloat)
        {
            Float();
        }        

        if (Input.GetMouseButtonDown(0))
        {
            Dash();
        }
    }

    void Jump()
    {
        rb2d.AddForce(transform.up * jumpForce);

        if(maxJumps == 0 && grounded)
        {
            rb2d.AddForce(transform.up * jumpForce);
        }
      
    }

    void Float()
    {
        if (!touchingWallRight || !touchingWallLeft)
        {
            rb2d.gravityScale = 0.5f;
        }
    }

    void Dash()
    {
        if (!grounded)
        {
            if (facingRight)
            {
                rb2d.AddForce(transform.right * airSpeed);
            }

            if (!facingRight)
            {
                rb2d.AddForce(-transform.right * airSpeed);
            }
        }
    }

    public void WallJump()
    {
        if (touchingWallRight && !grounded)
        {
            rb2d.AddForce(-transform.right * 200f);
            rb2d.AddForce(transform.up * 200f);
        }

        if (touchingWallLeft && !grounded)
        {
            rb2d.AddForce(transform.right * 200f);
            rb2d.AddForce(transform.up * 200f);
        }
    }
}
