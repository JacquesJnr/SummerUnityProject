using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamCheck : MonoBehaviour
{
    public GameObject player;
    private Animator anim;

    private void Start()
    {
        player = GameObject.Find("Player");
        anim = player.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("playerHurt", true);
        }

    }
}
