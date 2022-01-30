using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject Walls;

    private Rigidbody2D rb;
    private GameObject Boxes;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Boxes = gameObject.transform.parent.gameObject;
    }
    public void MoveBoxesCheck(Vector2 newPos, Vector2 MoveInput)
    {
        if (newPos == new Vector2 (transform.position.x, transform.position.y))
        {
            Move(MoveInput);
            for (int i = 0; i < Boxes.transform.childCount; i++)
            {
                if (new Vector2 (Boxes.transform.GetChild(i).position.x, Boxes.transform.GetChild(i).position.y) == rb.position + MoveInput && Boxes.transform.GetChild(i).name != gameObject.name)
                {
                    Boxes.transform.GetChild(i).GetComponent<Box>().MoveBoxesCheck(rb.position + MoveInput, MoveInput);
                }
                else
                {
                    return;
                }
            }
        }
        else { return; }
        
    }
    private void Move(Vector2 MoveInput)
    {
        
        if (!CheckIfMove(rb.position + MoveInput, MoveInput)) { return; }
        rb.MovePosition(rb.position + MoveInput);
    }
    private bool CheckIfMove(Vector2 newPos, Vector2 moveInput)
    {
        bool allow = true;
        for (int i = 0; i < Walls.transform.childCount; i++)
        {
            if (new Vector2(Walls.transform.GetChild(i).position.x, Walls.transform.GetChild(i).position.y) == newPos)
            {
                allow = false;
                break;
            }
        }
        for (int i = 0; i < Boxes.transform.childCount; i++)
        {
            if (new Vector2(Boxes.transform.GetChild(i).position.x, Boxes.transform.GetChild(i).position.y) == newPos)
            {
                allow = false;
                break;
            }
        }
        return allow;
    }

}
