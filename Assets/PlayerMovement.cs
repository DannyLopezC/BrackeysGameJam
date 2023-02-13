using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    public Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        var transformLocalScale = transform.localScale;
        transformLocalScale.x = movement.x != 0 ? movement.x : transformLocalScale.x;
        transform.localScale = transformLocalScale;
    }

    private void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.deltaTime));
    }
}