using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuScript: MonoBehaviour
{
    public List<GameObject> menuElements;
    private GameObject title, tapText, playButton;
    private Animator textAnim;
    private Animator elementAnim;
    private bool animComplete;
    private GameObject current;
    private float waitTime;

    private void Awake()
    {
        foreach (GameObject element in GameObject.FindGameObjectsWithTag("mainMenuElements"))
        {
            menuElements.Add(element);
            element.SetActive(false);
        }
    }

    private void Start()
    {
        title = GameObject.Find("TITLE");
        tapText = GameObject.Find("TapText");
        playButton = GameObject.Find("START_BUTTON");
        textAnim = title.GetComponent<Animator>();
        tapText.SetActive(false);
        playButton.SetActive(false);

        for (int i = 0; i < menuElements.Count; i++)
        {
            elementAnim = menuElements[0].GetComponent<Animator>();
        }
    }

    private void Update()
    {
        if (textAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !textAnim.IsInTransition(0))
        {
            animComplete = true;
        }

        if (elementAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !elementAnim.IsInTransition(0))
        {
            tapText.SetActive(true);
            playButton.SetActive(true);
        }

        if (animComplete)
        {
            Test();
        }
      
    }

    private void Test()
    {
        for(int i = 0; i < menuElements.Count; i++)
        {
            StartCoroutine(ShowElementsInOrder(1f));
        }
    }

    private IEnumerator ShowElementsInOrder(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < menuElements.Count; i++)
        {
            menuElements[i].SetActive(true);
        }
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("Element Tests");
    }



}
