using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    private Animator anim;
    public Animator textAnim;
    public RawImage book; // Book Screen
    public RawImage icon; // UI Icon
    public bool openBook; // Used to set the animator bool 

    public Canvas background; 
    public GameObject mainPage, tutorialPage, elementPage; //Menu text
    public GameObject ice, vine, rock, fire, movementTutorial; //Tutorial screens
    public GameObject exit, exit2, tapToExit; // X buttons
    private MovementClass movement; // Gets the player movement script

    void Start()
    {
        anim = book.gameObject.GetComponent<Animator>();
        book.enabled = false;
        movement = FindObjectOfType<MovementClass>();
        tutorialPage.SetActive(false);
        elementPage.SetActive(false);
        tapToExit.SetActive(false);
        background.enabled = false;

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

        anim.SetBool("BookOpen", openBook);
        textAnim.SetBool("openBook", openBook);
    }

    public void Icon() //Opens the menu when the book icon is pressed
    {
        book.enabled = true;
        openBook = true;
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
        book.enabled = false;
        tutorialPage.SetActive(false);
        movementTutorial.SetActive(true);
        tapToExit.SetActive(true);
        exit2.SetActive(true);
    }

    public void MovementToTutorials()
    {
        book.enabled = true;
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
        book.enabled = false;
        ice.SetActive(true);
        exit.SetActive(true);
        tapToExit.SetActive(true);
        background.enabled = true;
    }

    public void Vine()
    {
        book.enabled = false;
        vine.SetActive(true);
        exit.SetActive(true);
        tapToExit.SetActive(true);
        background.enabled = true;
    }

    public void Rock()
    {
        book.enabled = false;
        rock.SetActive(true);
        exit.SetActive(true);
        tapToExit.SetActive(true);
        background.enabled = true;
    }

    public void Fire()
    {
        book.enabled = false;
        fire.SetActive(true);
        exit.SetActive(true);
        tapToExit.SetActive(true);
        background.enabled = true;
    }

    public void CloseTutorial() //Closes all tutorial screens
    {
        book.enabled = true;
        ice.SetActive(false);
        vine.SetActive(false);
        rock.SetActive(false);
        fire.SetActive(false);
        movementTutorial.SetActive(false);
        exit.SetActive(false);
        tapToExit.SetActive(false);

    }
}
