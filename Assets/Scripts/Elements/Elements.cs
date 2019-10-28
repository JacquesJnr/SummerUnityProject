﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements : MonoBehaviour
{
    private MovementClass movement;
    private WaterInstances waterInstances;
    private OnScreen onScreen;
    private Swipe swipe;
    private Ice iceScript;

    private GameObject Player;
    private Animator anim;

    private GameObject water;
    public GameObject ice;

    public float climbSpeed = 0.05f;

    public bool lavaImmune;
    public bool burning;


    void Start()
    {
        movement = FindObjectOfType<MovementClass>(); //References the movement script
        waterInstances = FindObjectOfType<WaterInstances>(); // References the water instance script
        onScreen = FindObjectOfType<OnScreen>(); // References the onscreen script
        swipe = FindObjectOfType<Swipe>();
        iceScript = FindObjectOfType<Ice>();
        

        Player = this.gameObject; // Sets the pkayer variable
    }

    private void FixedUpdate()
    {
        water = onScreen.currentWater; // Checks which water body the player should interact with
    }


    void Update()
    {

        if (swipe.Right)
        {
            if (movement.grounded && onScreen.iceOnScreen)
            {
                Ice();
                onScreen.steamEffects.Stop();
                onScreen.steamEffects.GetComponent<Collider2D>().enabled = false;
                if (movement.anim.GetBool("playerHurt"))
                {
                    movement.anim.SetBool("playerHurt", false);
                }
            }
            
            //movement.DashRight();
            
        }

        if (swipe.Left)
        {
            
            //movement.DashLeft();
        }

    
        void Ice() //Checks to see if water is not a puddle and lays ice over the surface
        {
            if (onScreen.iceOnScreen)
            {
                iceScript.InstatiateIce();
            }
        }
    }
}
