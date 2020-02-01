using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;

    public Rigidbody rb;

    Vector3 movement;

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;

    // Update is called once per frame
    void Update()
    {
        // Input
        Vector2 temp_movement;
        temp_movement.x = 0;
        temp_movement.y = 0;

        if (Input.GetKey(moveUp))
        {
            temp_movement.y += 1;
        }
        if (Input.GetKey(moveDown))
        {
            temp_movement.y -= 1;
        }
        if (Input.GetKey(moveLeft))
        {
            temp_movement.x -= 1;
        }
        if (Input.GetKey(moveRight))
        {
            temp_movement.x += 1;
        }

        temp_movement.Normalize();

        movement = temp_movement;
    }

    void FixedUpdate()
    {
        // Movement
        rb.velocity = movement * moveSpeed;

        // Rotation
        //rb.MoveRotation(movement);
    }
}
