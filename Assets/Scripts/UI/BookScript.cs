using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookScript : MonoBehaviour
{
    private Animator anim;
    public RawImage book; // Book Screen
    public RawImage icon; // UI Icon
    private bool openBook; // Used to set the animator bool 

    public Canvas background; 
    public GameObject mainPage, tutorialPage, elementPage; //Menu text
    public GameObject ice, vine, rock, fire, movementTutorial; //Tutorial screens
    public GameObject exit, exit2; // X buttons
    private MovementClass movement; // Gets the player movement script

    void Start()
    {
        anim = book.gameObject.GetComponent<Animator>();
        book.enabled = false;
        movement = FindObjectOfType<MovementClass>();
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

    public void Icon() //Opens the menu when the book icon is pressed
    {
        book.enabled = true;
        openBook = true;
        anim.SetBool("BookOpen", openBook);
        StartCoroutine(ShowText());
    }

    public IEnumerator ShowText() //Adds a delay to when the text is shown
    {
        yield return new WaitForSeconds(0.6f);
        mainPage.SetActive(true);
        tutorialPage.SetActive(false);
        elementPage.SetActive(false);
        background.enabled = true;
    }


    public void Close() //Closes the menu completely
    {
        //Hide the book
        book.enabled = false;
        openBook = false;
        anim.SetBool("BookOpen", openBook);

        // Hide all text
        mainPage.SetActive(false);
        tutorialPage.SetActive(false);
        elementPage.SetActive(false);
        background.enabled = false;
    }

    // MENU NAVIGATION

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
        exit2.SetActive(true);
    }

    public void MovementToTutorials()
    {
        movementTutorial.SetActive(false);
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

    public void Ice()
    {
        ice.SetActive(true);
        exit.SetActive(true);
        background.enabled = true;
    }

    public void Vine()
    {
        vine.SetActive(true);
        exit.SetActive(true);
        background.enabled = true;
    }

    public void Rock()
    {
        rock.SetActive(true);
        exit.SetActive(true);
        background.enabled = true;
    }

    public void Fire()
    {
        fire.SetActive(true);
        exit.SetActive(true);
        background.enabled = true;
    }

    public void CloseTutorial() //Closes all tutorial screens
    {
        ice.SetActive(false);
        vine.SetActive(false);
        rock.SetActive(false);
        fire.SetActive(false);
        movementTutorial.SetActive(false);
        exit.SetActive(false);
       
    }
}
