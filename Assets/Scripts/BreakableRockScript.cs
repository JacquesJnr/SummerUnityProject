using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableRockScript : MonoBehaviour
{
    public int clickCounter;
    private void OnMouseDown()
    {
        clickCounter++;
    }

    // Update is called once per frame
    void Update()
    {
        if(clickCounter > 2)
        {
            Destroy(gameObject);
        }
    }
}
