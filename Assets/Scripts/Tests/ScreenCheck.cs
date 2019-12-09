using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCheck : MonoBehaviour
{
    public bool onScreen;

    void Start()
    {
        onScreen = true;
    }

    public void Update()
    {
        if (onScreen)
        {
            Debug.Log(gameObject.name + " is on screen");
        }
    }
}
