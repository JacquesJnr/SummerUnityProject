using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    public GameObject player;
    public GameObject icicle;
    private Animator anim;
    private bool shouldFall;
    private Vector2 fallSpeed = new Vector2(0, -8f);
    int runStateHash = Animator.StringToHash("Base Layer.IceWoble");

    private void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponentInParent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("PlayerEnter");
            this.GetComponent<Collider2D>().enabled = false;
            anim.SetBool("shouldFall", true);
        }
       
    }

    private void Update()
    {
        if (anim.GetBool("shouldFall"))
        {
         

        }

    }
}
