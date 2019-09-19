using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirections : MonoBehaviour
{
    private float speed = 5f;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        var autoscroll = collider.gameObject.GetComponent<MovementClass>();
        var player = GameObject.Find("Player");
        

        if(collider.gameObject.tag == "Player")
        {
            autoscroll.directionForce.x = autoscroll.directionForce.x * -Mathf.Abs(1);
        }
    }
}
