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
    public GameObject Walls;
    public GameObject Boxes;

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
        if (moveInput != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveInput);
        }
        if (!CheckIfMove(rb.position + moveInput, rb.position, moveInput)) { return; }
        
        for (int i = 0; i < Boxes.transform.childCount; i++)
        {
            if (new Vector2(Boxes.transform.GetChild(i).position.x, Boxes.transform.GetChild(i).position.y) == rb.position + moveInput)
            {
                Boxes.transform.GetChild(i).GetComponent<Box>().MoveBoxesCheck(rb.position + moveInput, moveInput);
            }
        }
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
            if (CheckIfMove(Player_past.GetComponent<Rigidbody2D>().position + LastMove, Player_past.GetComponent<Rigidbody2D>().position, LastMove))
            {
                
                Player_past.GetComponent<Rigidbody2D>().MovePosition(Player_past.GetComponent<Rigidbody2D>().position + LastMove);
                Player_past.GetComponent<SpriteRenderer>().enabled = true;

                for (int i = 0; i < Boxes.transform.childCount; i++)
                {
                    if (new Vector2(Boxes.transform.GetChild(i).position.x, Boxes.transform.GetChild(i).position.y) == Player_past.GetComponent<Rigidbody2D>().position + LastMove)
                    {
                        Boxes.transform.GetChild(i).GetComponent<Box>().MoveBoxesCheck(Player_past.GetComponent<Rigidbody2D>().position + LastMove, LastMove);
                    }
                }

            }
            else { Player_past.GetComponent<SpriteRenderer>().enabled = true; }
            
            step1.text = step2.text;
            step2.text = step3.text;
            step3.text = temp_step;
        }
    }
    private void UpdateSteps(string move)
    {
        if (step3.text == "None")
        {
            step3.text = move;
            return;
        }else if(step2.text == "None")
        {
            step2.text = step3.text;
            step3.text = move;
            return;
        }else if (step1.text == "None")
        {
            step1.text = step2.text;
            step2.text = step3.text;
            step3.text = move;
            return;
        }
        temp_step = move;
    }
    private bool CheckIfMove(Vector2 newPos, Vector2 curPos, Vector2 moveInput)
    {
        bool allow = true;
        for (int i = 0; i < Walls.transform.childCount; i++)
        {
            if (new Vector2 (Walls.transform.GetChild(i).position.x, Walls.transform.GetChild(i).position.y) == newPos)
            {
                allow = false;
                break;
            }
            for (int j = 0; j < Boxes.transform.childCount; j++)
            {
                if (new Vector2(Boxes.transform.GetChild(j).position.x, Boxes.transform.GetChild(j).position.y) + moveInput == new Vector2(Walls.transform.GetChild(i).position.x, Walls.transform.GetChild(i).position.y) 
                    && 
                    new Vector2(Boxes.transform.GetChild(j).position.x, Boxes.transform.GetChild(j).position.y) == newPos)
                {
                    allow = false;
                    break;
                }
                if (new Vector2(Boxes.transform.GetChild(j).position.x, Boxes.transform.GetChild(j).position.y) == newPos)
                {
                    if (j == 0)
                    {
                        if (new Vector2(Boxes.transform.GetChild(1).position.x, Boxes.transform.GetChild(1).position.y) == newPos+moveInput 
                            ||
                            new Vector2(Boxes.transform.GetChild(2).position.x, Boxes.transform.GetChild(2).position.y) == newPos + moveInput)
                        {
                            allow = false;
                            break;
                        }
                    }else if (j == 1)
                    {
                        if (new Vector2(Boxes.transform.GetChild(0).position.x, Boxes.transform.GetChild(0).position.y) == newPos + moveInput
                            ||
                            new Vector2(Boxes.transform.GetChild(2).position.x, Boxes.transform.GetChild(2).position.y) == newPos + moveInput)
                        {
                            allow = false;
                            break;
                        }
                    }else if (j == 2)
                    {
                        if (new Vector2(Boxes.transform.GetChild(0).position.x, Boxes.transform.GetChild(0).position.y) == newPos + moveInput
                            ||
                            new Vector2(Boxes.transform.GetChild(1).position.x, Boxes.transform.GetChild(1).position.y) == newPos + moveInput)
                        {
                            allow = false;
                            break;
                        }
                    }
                }
            }
        }
        
        return allow;
    }
}
