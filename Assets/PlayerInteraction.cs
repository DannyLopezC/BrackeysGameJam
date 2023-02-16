using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody2D currentBox;
    private Rigidbody2D collisionedBox;
    public Vector2 movement;
    public float moveSpeed = 5f;

    public bool grabbed;

    public void PickBox(GameObject box)
    {
        collisionedBox = box.GetComponent<Rigidbody2D>();
    }

    public void DropBox()
    {
        Debug.Log($"hello");
        collisionedBox = null;
        currentBox = null;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            grabbed = true;
            currentBox = collisionedBox;
        }
        else
        {
            grabbed = false;
            currentBox = null;
        }

        if (currentBox != null & grabbed)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
    }

    private void FixedUpdate()
    {
        if (currentBox != null && grabbed)
        {
            currentBox.MovePosition(currentBox.position + movement * (moveSpeed * Time.deltaTime));
        }
    }
}