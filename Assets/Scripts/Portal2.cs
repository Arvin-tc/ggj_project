using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour
{

    public GameObject portal;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            collision.transform.position = portal.transform.position;
        }

        portal.SetActive(false);
        gameObject.SetActive(false);
    }
}
