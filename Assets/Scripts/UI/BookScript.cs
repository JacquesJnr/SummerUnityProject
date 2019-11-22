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
    public RawImage book2;
    public RawImage icon;
    private bool openBook;
    private bool closeBook;

    public Canvas inputCanvas;
    public Canvas menuCanvas;
    public Canvas background;
    public GameObject mainPage, tutorialPage, elementPage;
    public GameObject ice, vine, rock, fire, movementTutorial;
    public GameObject exit, exit2;

    private MovementClass movement;

    void Start()
    {
        anim = GetComponent<Animator>();
        book.enabled = false;
        movement = FindObjectOfType<MovementClass>();
        menuCanvas.enabled = false;
        //background.enabled = false;
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
        background.enabled = false;
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

    public void TutorialToMovement()
    {
        tutorialPage.SetActive(false);
        movementTutorial.SetActive(true);
        book2.enabled = false;
        exit2.SetActive(true);
    }

    public void MovementToTutorials()
    {
        movementTutorial.SetActive(false);
        book2.enabled = true;
        tutorialPage.SetActive(true);
        exit2.SetActive(false);
    }

    public void ElementsToTutorials()
    {
        elementPage.SetActive(false);
        tutorialPage.SetActive(true);
    }

    public void TutorialsToMenu()
    {
        tutorialPage.SetActive(false);
        mainPage.SetActive(true);
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
 
    public void Ice()
    {
        ice.SetActive(true);
        exit.SetActive(true);
        background.enabled = true;
        book2.enabled = false;
    }

    public void Vine()
    {
        vine.SetActive(true);
        exit.SetActive(true);
        background.enabled = true;
        book2.enabled = false;
    }

    public void Rock()
    {
        rock.SetActive(true);
        exit.SetActive(true);
        background.enabled = true;
        book2.enabled = false;
    }

    public void Fire()
    {
        fire.SetActive(true);
        exit.SetActive(true);
        background.enabled = true;
        book2.enabled = false;
    }

    public void CloseTutorial()
    {
        ice.SetActive(false);
        vine.SetActive(false);
        rock.SetActive(false);
        fire.SetActive(false);
        movementTutorial.SetActive(false);
        book2.enabled = true;
        exit.SetActive(false);
       
    }
}
