using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam : MonoBehaviour
{
    private CapsuleCollider2D steamPushArea;
    private Vector2 pushForce;
    public bool inTrigger;

    private MovementClass movement;

    void Start()
    {
        steamPushArea = GetComponent<CapsuleCollider2D>();
        pushForce = new Vector2(10, 0);
        movement = FindObjectOfType<MovementClass>();
    }

    
    void Update()
    {
        if (inTrigger)
        {
           
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inTrigger = true;

            var magnitude = 9f;

            var force = transform.position - collision.transform.position;

            force.Normalize();
            movement.rb2d.AddForce(-force * magnitude);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }
}
