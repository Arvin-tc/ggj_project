using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Vector2 moveInput;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Box")
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            Debug.Log(Helper());
            rb.MovePosition(rb.position + moveInput);
        }
    }
    private Vector2 Helper()
    {
        float vertical = 0;
        float horizontal = 0;
        if (Input.GetKeyDown(KeyCode.A))
        {
            horizontal = -1;
            return moveInput = new Vector2(horizontal, vertical);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            horizontal = 1;
            return moveInput = new Vector2(horizontal, vertical);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            vertical = 1;
            return moveInput = new Vector2(horizontal, vertical);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            vertical = -1;
            return moveInput = new Vector2(horizontal, vertical);
        }
        return moveInput;
    }
}
