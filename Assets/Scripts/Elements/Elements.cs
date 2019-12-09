using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements : MonoBehaviour
{
    private MovementClass movement;
    private WaterInstances waterInstances;
    private OnScreen onScreen;
    private Swipe swipe;
    private Ice iceScript;

    private GameObject Player;
    private Animator anim;

    private GameObject water;
    public GameObject ice;

    public float climbSpeed = 0.05f;

    public bool lavaImmune;
    public bool burning;


    void Start()
    {
        movement = FindObjectOfType<MovementClass>(); //References the movement script
        onScreen = FindObjectOfType<OnScreen>(); // References the onscreen script
        swipe = FindObjectOfType<Swipe>();
        iceScript = FindObjectOfType<Ice>();
        

        Player = this.gameObject; // Sets the pkayer variable
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        movement.anim.SetBool("powerUp", false);
    }

    private void FixedUpdate()
    {
        water = onScreen.currentWater; // Checks which water body the player should interact with
        
        if(swipe.Right || swipe.Left || swipe.Up || swipe.Down)
        {
            movement.anim.SetBool("powerUp", true);
            StartCoroutine(Wait());
        }

    }


    void Update()
    {

      
        if (swipe.Right)
        {
            if (movement.grounded && onScreen.iceOnScreen)
            {
                iceScript.InstatiateIce();
                onScreen.steamEffects.Stop();
                onScreen.steamEffects.GetComponent<CapsuleCollider2D>().enabled = false;             
                onScreen.steamEffects.GetComponent<BoxCollider2D>().enabled = false;             
            }
           
        }
    }
}
