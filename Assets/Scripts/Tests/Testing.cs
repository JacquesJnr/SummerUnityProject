using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private FunctionTimer functionTimer;

    // Start is called before the first frame update
    void Start()
    {
        FunctionTimer.Create(TestingAction, 3f);    
    }

    private void TestingAction()
    {
        Debug.Log("Testing");
    }
}
