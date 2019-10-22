﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public GameObject ice;
    public GameObject waterPos;
    private BoxCollider2D box;
    Vector2 slideForward;
    Vector2 slideBackward;

    private OnScreen onScreen;
    private MovementClass movement;
    

    private void Start()
    {
        onScreen = FindObjectOfType<OnScreen>();
        movement = FindObjectOfType<MovementClass>();
        box = this.gameObject.GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        waterPos = onScreen.currentIcePos;
    }

    public void InstatiateIce()
    {
        Instantiate(ice, waterPos.transform.position, transform.rotation);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            slideForward = new Vector2(0.5f, 0);
            slideBackward = new Vector2(-0.5f, 0);
            if (movement.facingRight)
            {
                movement.rb2d.AddForce(slideForward);
            }
            if (!movement.facingRight)
            {
                movement.rb2d.AddForce(slideBackward);
            }
        }
    }
}