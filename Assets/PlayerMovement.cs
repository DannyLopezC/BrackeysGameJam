using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    public Vector2 movement;

    public Sprite upIdle;
    public Sprite downIdle;
    public Sprite rightIdle;
    public Sprite leftIdle;

    public SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0) spriteRenderer.sprite = rightIdle;
        else if (movement.y < 0) spriteRenderer.sprite = downIdle;
        else if (movement.y < 0) spriteRenderer.sprite = upIdle;

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