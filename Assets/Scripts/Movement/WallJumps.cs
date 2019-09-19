using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumps : MonoBehaviour
{
    private MovementClass movement;

    private float wallCheckRadius = 0.05f;
    public Collider2D player;

     void Start()
    {
        movement = GameObject.FindObjectOfType<MovementClass>();    
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && this.GetComponent<Collider2D>().IsTouching(player))
        {
            movement.WallJump();
        }
    }
}
