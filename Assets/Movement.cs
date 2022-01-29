using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector2 moveInput;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = 0;
        float horizontal = 0;
        if (Input.GetKeyDown(KeyCode.A))
        {
            horizontal = -1;
            moveInput = new Vector2(horizontal, vertical);
            Move();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            horizontal = 1;
            moveInput = new Vector2(horizontal, vertical);
            Move();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            vertical = 1;
            moveInput = new Vector2(horizontal, vertical);
            Move();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            vertical = -1;
            moveInput = new Vector2(horizontal, vertical);
            Move();
        }
        
    }
    private void Move()
    {
        rb.MovePosition(rb.position + moveInput);
    }
}
