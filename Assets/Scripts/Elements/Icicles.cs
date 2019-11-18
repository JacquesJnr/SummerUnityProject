using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicles : MonoBehaviour
{
    public GameObject player, icicle;
    private Animator anim;
    private Rigidbody2D rb2d;
    private MovementClass movement;

    public bool broken;
    public bool inTrigger;
    private float checkRadius = 3.5f;
    public LayerMask whatIsPlayer;

    private void Start()
    {
        player = GameObject.Find("Player");
        movement = FindObjectOfType<MovementClass>();
        anim = GetComponentInParent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        icicle = this.gameObject;
    }

    private void FixedUpdate()
    {
        inTrigger = Physics2D.OverlapCircle(icicle.transform.position, checkRadius, whatIsPlayer);
    }


    private void Update()
    {
        anim.SetBool("inTrigger", inTrigger);


        if (inTrigger)
        {
            StartCoroutine(IceBreak());
        }


        if (broken)
        {
            IceFall();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
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
