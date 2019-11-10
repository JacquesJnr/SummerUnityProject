using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookScript : MonoBehaviour
{
    // Open Book when the book button is pressed
    // Hide the book when they press the exit button

    private Animator anim;
    public RawImage book;
    public RawImage icon;
    private bool openBook;
    private bool closeBook;

    public Canvas inputCanvas;
    public Canvas menuCanvas;
    public GameObject mainPage;
    public GameObject tutorialPage;
    public GameObject elementPage;

    private MovementClass movement;

    void Start()
    {
        anim = GetComponent<Animator>();
        book.enabled = false;
        movement = FindObjectOfType<MovementClass>();
        menuCanvas.enabled = false;
        tutorialPage.SetActive(false);
        elementPage.SetActive(false);
    }

    private void Update()
    {
        if (openBook)
        {
            movement.enabled = false;
        }
        else
        {
            movement.enabled = true;
        }
    }

    public void Icon()
    {
        book.enabled = true;
        openBook = true;
        anim.SetBool("BookOpen", openBook);
        StartCoroutine(ShowText());
    }

    public void Close()
    {
        
        //Hide the book
        book.enabled = false;
        openBook = false;
        anim.SetBool("BookOpen", openBook);

        // Switch the canvases
        inputCanvas.enabled = true;
        menuCanvas.enabled = false;
    }

    public void MenuToTutorial()
    {
        // Switch the page texts
        mainPage.SetActive(false);
        tutorialPage.SetActive(true);
    }

    public void TutorialToElements()
    {
        tutorialPage.SetActive(false);
        elementPage.SetActive(true);
    }

    public IEnumerator ShowText()
    {
        yield return new WaitForSeconds(0.6f);
        menuCanvas.enabled = true;
        inputCanvas.enabled = false;
        mainPage.SetActive(true);
        tutorialPage.SetActive(false);
        elementPage.SetActive(false);
    }
 
}
