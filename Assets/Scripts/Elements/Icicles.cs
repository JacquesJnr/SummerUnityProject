using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicles : MonoBehaviour
{
    public GameObject Player;
    private MovementClass movement;

    private void Start()
    {
        Player = GameObject.Find("Player");
        movement = FindObjectOfType<MovementClass>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            movement.anim.SetBool("playerHurt", true);
        }
    }
}
