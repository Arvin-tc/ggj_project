using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1 : MonoBehaviour
{

    public GameObject portal;


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if player touch the trigger
        if (collision.tag == "Player") 
        {
            // move player to another portal position
            collision.transform.position = portal.transform.position; 
        }

        portal.gameObject.SetActive(false);
        gameObject.SetActive(false);

    }
}
