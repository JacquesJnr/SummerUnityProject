using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class MovementClass : MonoBehaviour
{
    //Player Physics
    [HideInInspector]
    public Rigidbody2D rb2d;
    private GameObject Player;
    private Vector2 velocity;
    private int groundspeed;
    public float playerSpeed = 1f;
    private float airSpeed = 200f;
    private float climbSpeed = 100f;
    private float slideSpeed;
    public bool facingRight;
    public bool grounded;
    public bool sliding;
    public bool holdingJump;
    public float minGroundNormalY = .85f;

    // World Physics
    public Transform groundCheck;
    private float checkRadius = 0.05f;
    private float minMoveDistance = 0.01f;
    private ContactFilter2D contactFilter;
    public LayerMask whatIsGround;
    public LayerMask whatIsIce;
    public LayerMask whatIsOnScreen;

    //Collisions
    public RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    [SerializeField]
    private List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);
    private Vector2 groundNormal;
    private bool touchingWallRight;
    private bool touchingWallLeft;
    public bool onIce;
    public PhysicsMaterial2D icy;
    private float wallCheckRadius = 0;
    private float vineCheckRadius = 0.1f;
    public Transform RightWallCheck;
    public Transform LeftWallCheck;
    public Transform VineWallCheck;

    //JumpPhysics
    private bool doubleJump;
    private float jumpForce = 150f;
    private float doubleJumpForce = 170f;
    private int maxJumps = 1;
    public int maxJumpValue;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public bool canFloat;

    // Animations
    public Animator anim;
   
    //Other Scripts    
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

        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(whatIsOnScreen);
        contactFilter.useLayerMask = true;
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        onIce = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsIce);
        touchingWallRight = Physics2D.OverlapCircle(RightWallCheck.position, wallCheckRadius, whatIsGround);
        touchingWallLeft = Physics2D.OverlapCircle(LeftWallCheck.position, wallCheckRadius, whatIsGround);
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        if (!touchingWallRight || !touchingWallLeft) // Player will not move forward while they are touching a wall
        {
            transform.Translate(velocity * playerSpeed * Time.deltaTime);
        }

        groundspeed = (int)velocity.x;

        if (rb2d.velocity.y < 0 && maxJumps == 0) // Checks if the player is falling and has no jumps
        {
            canFloat = true;
        }
        else
        {
            canFloat = false;
        }

        if (!grounded)
        {
            holdingJump = false;
        }

        if (grounded)
        {
            doubleJump = false;
            anim.SetBool("doubleJump", false);
            rb2d.gravityScale = 2f;
        }

        if (holdingJump && velocity.x !=0)
        {
            velocity.x = 0f;
        }

        NormalizeSlope();

    }

    void Update()
    {
       
        if (grounded) //Resets Jump Values
        {
            maxJumps = maxJumpValue;
            doubleJump = false;
        }
      
        if(velocity.x > 0 && !facingRight) //Flips the character sprite
        {
            Flip(velocity.x);
        }

        if(velocity.x < 0 && facingRight)
        {
            Flip(velocity.x);
        }

        if (anim.GetBool("playerHurt"))
        {
            StartCoroutine(Hurt());
        }

        anim.SetInteger("velocityX", groundspeed); // Checks the speed of the player in the animator
        anim.SetBool("grounded", grounded); //Checks if the player is grounded in the animator

           #region PCInputs 

        // Tests Controls on PC
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            DontMove();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetButton("Jump"))
        {
            anim.SetBool("holdingJump", true);
            holdingJump = true;
        }
        else
        {
            holdingJump = false;
        }

        if(canFloat)
        {
            Float();
        }

        if (Input.GetButtonUp("Jump"))
        {
            if (maxJumps >= 1)
            {
                maxJumps--;
                Jump();
            }

        }

        #endregion

    }

    private IEnumerator Hurt()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("playerHurt", false);
    }

    public void MoveRight()
    {
        if (!holdingJump)
        {
            velocity.x = 9f;
            airSpeed = 5f;
        }
    }

    public void MoveLeft()
    {
        if (!holdingJump)
        {
            velocity.x = -9f;
            airSpeed = -5f;
        }   
    }

    public void DontMove()
    {
       velocity.x = 0f;
    }

    public void HoldJump() // Allows the player to jump higher depending on how long the player hold the jump button
    {
        if(rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb2d.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        holdingJump = true;
        anim.SetBool("holdingJump", true);
    }
    
   
    public void TouchToJump()
    {
        if (maxJumps >= 1)
        {
            maxJumps--;
            Jump();
        }
    }


    public void Jump()
    {
        anim.SetBool("holdingJump", false);

        if (!canFloat)
        {
            rb2d.AddForce(transform.up * jumpForce);

            // Grounded Jump
            if (maxJumps == 0 && grounded)
            {
                rb2d.AddForce(transform.up * jumpForce);
            }

            // Double Jump
            else if (maxJumps == 0 && !grounded)
            {
                rb2d.AddForce(transform.up * doubleJumpForce);
                anim.SetBool("doubleJump", true);
            }
        }
       
    }

    void Float()
    {
        if (Input.GetButton("Jump") && !grounded)
        {
            rb2d.gravityScale = 0.5f;
            anim.SetBool("Floating", true);
        }
        else
        {
            anim.SetBool("Floating", false);
            rb2d.gravityScale = 2f;
        }
    }

    public void DashRight()
    {
        if (!grounded)
        {
            
            rb2d.transform.Translate(velocity * airSpeed *Time.deltaTime);

        }
    }

    public void DashLeft()
    {
        if (!grounded)
        {
           
            rb2d.transform.Translate(velocity * -airSpeed);
        }
       
    }

    void NormalizeSlope()
    {
        
        // Attempt vertical normalization
        if (grounded)
        {
            //Debug.Log("Here I go!");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f, whatIsGround);
            
            if (hit.collider != null && Mathf.Abs(hit.normal.x) > 0.1f)
            {
                // Apply the opposite force against the slope force 
                // You will need to provide your own slopeFriction to stabalize movement
                rb2d.velocity = new Vector2(velocity.x - (hit.normal.x * 9f), rb2d.velocity.y);

                //Move Player up or down to compensate for the slope below them
                Vector3 pos = transform.position;
                pos.y += -hit.normal.x * Mathf.Abs(velocity.x) * Time.deltaTime * (velocity.x - hit.normal.x > 0 ? 1 : -1);
                transform.position = pos;
            }
        }
    }

    public void Flip(float horizontal)
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}