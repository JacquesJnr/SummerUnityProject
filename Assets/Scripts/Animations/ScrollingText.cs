using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingText : MonoBehaviour
{
    public float delay = 0.1f;
    public string fulltext;
    private string currentText = "";
    public Text welcomeMessage;

    public void ShowText() // Calls the IEnumerator function below
    {
        StartCoroutine(TextScroll());
    }

    public void StopText() //Stops the text from scrolling
    {
        StopCoroutine(TextScroll());
    }

    public IEnumerator TextScroll()
    {
        for (int i = 0; i <= fulltext.Length; i++) // This for loop runs through the length of my fulltext variable and prints the string letter by letter 
        {
            currentText = fulltext.Substring(0, i);
            welcomeMessage.text = currentText;
            yield return new WaitForSeconds(delay); // This waits a set amount of time before printing the next letter
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
