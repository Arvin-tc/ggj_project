using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public GameObject Player_past;
    public Vector2 moveInput;
    public Vector2 LastMove;
    public Text step1;
    public Text step2;
    public Text step3;

    private Rigidbody2D rb;
    private Queue<Vector2> record = new Queue<Vector2>();
    private string temp_step;

    
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
            UpdateSteps("←");
            Move();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            horizontal = 1;
            moveInput = new Vector2(horizontal, vertical);
            record.Enqueue(moveInput);
            UpdateSteps("→");
            Move();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            vertical = 1;
            moveInput = new Vector2(horizontal, vertical);
            record.Enqueue(moveInput);
            UpdateSteps("↑");
            Move();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            vertical = -1;
            moveInput = new Vector2(horizontal, vertical);
            record.Enqueue(moveInput);
            UpdateSteps("↓");
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
            LastMove = record.Dequeue();
            Player_past.GetComponent<Rigidbody2D>().MovePosition(Player_past.GetComponent<Rigidbody2D>().position + LastMove);
            step1.text = step2.text;
            step2.text = step3.text;
            step3.text = temp_step;
        }
    }
    private void UpdateSteps(string move)
    {
        if (step1.text == "None")
        {
            step1.text = move;
            return;
        }else if(step2.text == "None")
        {
            step2.text = move;
            return;
        }else if (step3.text == "None")
        {
            step3.text = move;
            return;
        }
        temp_step = move;
    }
}
