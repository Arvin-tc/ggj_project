using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal3 : MonoBehaviour
{
    public GameObject portal;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //portal.GetComponent<BoxCollider2D>().enabled = false;
       
        if (collision.tag == "Player")
        {
            collision.transform.position = portal.transform.position;
        }
       
    }

    
}
