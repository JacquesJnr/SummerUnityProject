using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicles : MonoBehaviour
{
    public GameObject player, icicle; 
    private Animator anim;
    private Rigidbody2D rb2d;
    private MovementClass movement; // Gets the player movement script

    public bool broken; //Used to check if the icicle should fall
    public bool inTrigger; // Used to check if the player is in range of the icicles in an overlap circle
    private float checkRadius = 3.5f; //Overlap circle radius
    public LayerMask whatIsPlayer; // Layermask for the overlap circle

    private void Start()
    {
        player = GameObject.Find("Player");
        movement = FindObjectOfType<MovementClass>(); //Used to grab varibles from the player movement script
        anim = GetComponentInParent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        icicle = this.gameObject;
    }

    private void FixedUpdate()
    {
        inTrigger = Physics2D.OverlapCircle(icicle.transform.position, checkRadius, whatIsPlayer); //Draws the overlap circle
    }


    private void Update()
    {
        anim.SetBool("inTrigger", inTrigger);


        if (inTrigger) // Make the icicles wobble if the player steps on range
        {
            StartCoroutine(IceBreak());
        }


        if (broken) //If the coroutine is completed make the icicle drop
        {
            IceFall();
        }
    }

    private void OnCollisionStay2D(Collision2D collision) //Checks for collosions on the icicle
    {
        if (collision.gameObject.tag == "Player")
        {
            rb2d.isKinematic = true;
            Object.Destroy(icicle);
            movement.anim.SetBool("playerHurt", true);
        }

        if (collision.gameObject.tag == "platforms")
        {
            rb2d.isKinematic = true;
            icicle.GetComponent<Collider2D>().isTrigger = true;
            Object.Destroy(icicle);
        }
    }

    public void IceFall()
    {
        rb2d.isKinematic = false;
        rb2d.bodyType = RigidbodyType2D.Dynamic;
    }

    private IEnumerator IceBreak()
    {
        yield return new WaitForSeconds(0.5f);

        if (inTrigger)
        {
            broken = true;
        }
    }

    
}
