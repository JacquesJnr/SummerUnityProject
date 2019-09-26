using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterInstances : MonoBehaviour
{

    public Transform fullPos; // Where the water level should rise to
    public bool puddle;
    private GameObject water;
    private GameObject icePos;

    private OnScreen onScreen; //References the onscreen script

    public void Start()
    {
        onScreen = FindObjectOfType<OnScreen>();
    }

    public void Update()
    {
        water = onScreen.currentWater; // Checks the current water body the player wants to interact with
        icePos = onScreen.currentIcePos;
    }

   
}
