using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingFire : MonoBehaviour
{
    public bool fireOn = false;

    void OnMouseDown()
    {
        Debug.Log("Fire Clicked");
        fireOn = true;
    }
}
