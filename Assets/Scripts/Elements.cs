using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements : MonoBehaviour
{
    [SerializeField] private MovementClass movement;
    [SerializeField] private WaterInstances waterInstances;
    [SerializeField] private OnScreen onScreen;

    private GameObject Player;
    private Animator anim;

    public GameObject rainCloud;
    private GameObject water;
    public GameObject ice;
    public bool puddle;

    public float climbSpeed = 0.05f;

    public bool lavaImmune;
    public bool burning;


    void Start()
    {
        movement = FindObjectOfType<MovementClass>(); //References the movement script
        waterInstances = FindObjectOfType<WaterInstances>(); // References the water instance script
        onScreen = FindObjectOfType<OnScreen>(); // References the onscreen script
        

        Player = this.gameObject; // Sets the pkayer variable
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(rainCloud.transform.position, -Vector2.up, 5.5f); //Checks if the water below a rain cloud is a puddle

        water = onScreen.currentWater; // Checks which water body the player should interact with

        if (hit.collider.CompareTag("puddle"))
        {
            puddle = true;
        }
        else
        {
            puddle = false;
        }
    }


    void Update()
    {
      

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine("Rain");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Ice(); 
        }

        if (movement.touchingVineWall)
        {
            ClimbVines();
        }

        if (movement.inLava)
        {
            InTheLava();
        }
    }

    IEnumerator Rain() //Spawns the Rain cloud for a set time
    {
        rainCloud.SetActive(true);
        waterInstances.MoveWater(); // Calls a function from WaterInstances
        yield return new WaitForSeconds(2f);
        rainCloud.SetActive(false);
    }

    void Ice() //Checks to see if water is not a puddle and lays ice over the surface
    {
        anim = ice.GetComponent<Animator>();

        if (!puddle)
        {
           // anim.Play("Ice");
            anim.Play("IceTests");
        }
    }

    void ClimbVines() //Lets the player climb up vines
    {
        if (Input.GetButton("Jump"))
        {
            movement.rb2d.velocity = new Vector2(0,5);
        }
    }

    void InTheLava() //Checks if the player is inside lava and if they are immune
    {
       if(!lavaImmune)
       {
            StartCoroutine("Burn");
            burning = true;
        }
        else
        {
            burning = false;
        }
    }

    IEnumerator Burn() // Makes the player burn for a set time
    {
        Debug.Log("Burn");
        anim = Player.GetComponent<Animator>();
        yield return new WaitForSeconds(2);
        anim.Play("Burn");
        movement.directionForce.x = 0f;
    }
}
