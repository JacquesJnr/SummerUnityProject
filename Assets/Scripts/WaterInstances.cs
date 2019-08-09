using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterInstances : MonoBehaviour
{

    public Transform fullPos; // Where the water level should rise to
    private GameObject water;

    private OnScreen onScreen; //References the onscreen script

    public void Start()
    {
        onScreen = FindObjectOfType<OnScreen>();
    }

    public void Update()
    {
        water = onScreen.currentWater; // Checks the current water body the player wants to interact with
    }

    public void MoveWater() // Moves the water to the target full position - fullPos
    {
        if(water.transform.localPosition.y < fullPos.localPosition.y) 
        {
            water.transform.Translate(transform.up * 0.5f);
            water.tag = "Untagged";
        }
        else
        {
            Debug.Log(water.name + " Can't go Higher");
        }
    }
}
