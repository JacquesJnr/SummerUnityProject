using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaScript : MonoBehaviour
{
    public GameObject Player;
    public ActivatingFire fireImmune;
    public bool inTheLava, immune = false;
    
    // Update is called once per frame
    void Update()
    {
        immune = fireImmune;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            InTheLava();
            inTheLava = true;
        }
        
    }
    void InTheLava()
    {
        if (inTheLava && !immune)
        {
            Debug.Log("In the lava and not immune");
            StartCoroutine("Wait");
        }
    }
    IEnumerator Wait()
    {

        yield return new WaitForSeconds(3);
        Destroy(Player);
    }
}

