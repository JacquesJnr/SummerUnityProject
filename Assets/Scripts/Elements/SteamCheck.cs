using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamCheck : MonoBehaviour
{
    public GameObject player;
    private Animator anim;

    private MovementClass movement;

    private void Start()
    {
        player = GameObject.Find("Player");
        movement = FindObjectOfType<MovementClass>();
        anim = player.GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //anim.SetBool("playerHurt", true);
            
        }
    }

}
