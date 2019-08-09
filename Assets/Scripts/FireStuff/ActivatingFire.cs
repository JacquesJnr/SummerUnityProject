using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatingFire : MonoBehaviour
{
    public StartingFire fireOn;
    public bool fireImmune = false;

    void OnMouseDown()
    {
        if (fireOn)
        {
            StartCoroutine("Wait");
           
        }
    }

    IEnumerator Wait()
    {
        fireImmune = true;
        yield return new WaitForSeconds(5);
        fireImmune = false;
    }
}

