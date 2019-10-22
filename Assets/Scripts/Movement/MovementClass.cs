using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class MovementClass : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rb2d;
    private GameObject Player;
    private Vector2 velocity;
    public float playerSpeed = 1f;
    public float jumpForce = 10f;
    private float airSpeed = 200f;
    private float climbSpeed = 100f;
    private float slideSpeed;

    public bool facingRight;
    public bool grounded;
    public bool sliding;
    public Transform groundCheck;
    private float checkRadius = 0.05f;
    public LayerMask whatIsGround;
    public LayerMask whatIsIce;

    private bool touchingWallRight;
    private bool touchingWallLeft;
    public bool onIce;
    public PhysicsMaterial2D icy;
    private float wallCheckRadius = 0;
    private float vineCheckRadius = 0.1f;
    public Transform RightWallCheck;
    public Transform LeftWallCheck;
    public Transform VineWallCheck;
    

    private int maxJumps = 1;
    public int maxJumpValue;
    public bool canFloat;

    public Sprite walking;
    public Sprite idle;
    public Animator anim;
    public Button RightButton;
    public Button LeftButton;
            
    private Swipe swipe;

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        maxJumps = maxJumpValue;
        velocity.x = 0f;
        facingRight = true;
        anim = GetComponent<Animator>();

        swipe = FindObjectOfType<Swipe>();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        onIce = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsIce);
        touchingWallRight = Physics2D.OverlapCircle(RightWallCheck.position, wallCheckRadius, whatIsGround);
        touchingWallLeft = Physics2D.OverlapCircle(LeftWallCheck.position, wallCheckRadius, whatIsGround);

        if (grounded) // Resets the gravity
        {
            rb2d.gravityScale = 2;
        }

        if (!touchingWallRight || !touchingWallLeft) // Player will not move forward while they are touching a wall
        {
            transform.Translate(velocity * playerSpeed * Time.deltaTime);
        }

        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");


        if (rb2d.velocity.y < 0 && maxJumps == 0 && !touchingWallLeft && !touchingWallRight) // Checks if the player is falling and has no jumps
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
      
        if(velocity.x > 0 && !facingRight)
        {
            Flip(velocity.x);
        }

        if(velocity.x < 0 && facingRight)
        {
            Flip(velocity.x);
        }
    }

    public void MoveRight()
    {
        velocity.x = 9f;
        airSpeed = 5f;
        Player.GetComponent<SpriteRenderer>().sprite = walking;
    }

    public void MoveLeft()
    {
        velocity.x = -9f;
        airSpeed = -5f;
        Player.GetComponent<SpriteRenderer>().sprite = walking;
    }

    public void DontMove()
    {
       velocity.x = 0f;
       Player.GetComponent<SpriteRenderer>().sprite = idle;
    }
    
    public void TouchToJump()
    {
        if(maxJumps >= 1)
        {
            maxJumps--;
            Jump();
        }
    }

    public void Jump()
    {
        rb2d.AddForce(transform.up * jumpForce);

        if (maxJumps == 0 && grounded)
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

    public void DashRight()
    {
        if (!grounded)
        {
            Player.GetComponent<SpriteRenderer>().sprite = walking;
            rb2d.transform.Translate(velocity * airSpeed *Time.deltaTime);

        }
    }

    public void DashLeft()
    {
        if (!grounded)
        {
            Player.GetComponent<SpriteRenderer>().sprite = walking;
            rb2d.transform.Translate(velocity * -airSpeed);
        }
       
    }

    void Slide()
    {
       
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Icicle")
    //    {
    //        anim.SetBool("playerHurt", true);
    //    }
       
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Icicle")
    //    {
    //        anim.SetBool("playerHurt", false);
    //    }
    //}


    public void Flip(float horizontal)
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
