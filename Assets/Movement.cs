using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Player_past;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Queue<Vector2> record = new Queue<Vector2>();

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //current movement
        float vertical = 0;
        float horizontal = 0;
        if (Input.GetKeyDown(KeyCode.A))
        {
            horizontal = -1;
            moveInput = new Vector2(horizontal, vertical);
            record.Enqueue(moveInput);
            Move();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            horizontal = 1;
            moveInput = new Vector2(horizontal, vertical);
            record.Enqueue(moveInput);
            Move();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            vertical = 1;
            moveInput = new Vector2(horizontal, vertical);
            record.Enqueue(moveInput);
            Move();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            vertical = -1;
            moveInput = new Vector2(horizontal, vertical);
            record.Enqueue(moveInput);
            Move();
        }
        //start player_past movement
        past_move();
    }
    private void Move()
    {
        rb.MovePosition(rb.position + moveInput);
    }
    //player_past movement
    private void past_move()
    {
        if (record.Count < 4)
        {
            return;
        }
        else
        {
            Player_past.GetComponent<Rigidbody2D>().MovePosition(Player_past.GetComponent<Rigidbody2D>().position + record.Dequeue());
        }
    }
}
