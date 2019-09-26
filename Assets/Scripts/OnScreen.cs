using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreen : MonoBehaviour
{
    public List<GameObject> water; // List of water bodies in on screen
    public List<GameObject> icePositions;
    public GameObject currentWater; // The first water body on screen
    public GameObject currentIcePos;

    public void Start()
    {
        water = new List<GameObject>();
        icePositions = new List<GameObject>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "puddle")
        {
            AddWater(collision.gameObject); // Calls the AddWater function and passes the objects inside the camera collider
            currentWater = water[0];
        }

        if(collision.gameObject.tag == "icePosition")
        {
            AddIce(collision.gameObject);
            currentIcePos = icePositions[0];
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        water.Remove(collision.gameObject); // Removes water objects from water list
        icePositions.Remove(collision.gameObject); 
    }

    void AddWater(GameObject obj) // Adds a gameobject to the water list
    {
        if (!water.Contains(obj))
        {
            water.Add(obj);
        } 
    }

    void AddIce(GameObject obj)
    {
        if (!icePositions.Contains(obj))
        {
            icePositions.Add(obj);
        }
    }
}