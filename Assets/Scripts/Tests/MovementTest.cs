using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{

    public float runspeed = 100f;
    public float horizontalMove;

    private CharController2D charController;



    private void Start()
    {
        charController = FindObjectOfType<CharController2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
    }

    private void FixedUpdate()
    {
        charController.Move(horizontalMove * Time.fixedDeltaTime, false);
    }

}
