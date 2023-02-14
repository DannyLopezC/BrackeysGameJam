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

    public SpriteRenderer spriteRenderer;

    private static readonly int FacingSide = Animator.StringToHash("FacingSide");
    private static readonly int FacingUp = Animator.StringToHash("FacingUp");
    private static readonly int FacingDown = Animator.StringToHash("FacingDown");

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        PlayerRotation();
    }

    private void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.deltaTime));
    }

    private void PlayerRotation()
    {
        if (movement.x != 0)
        {
            animator.SetBool(FacingSide, true);
            animator.SetBool(FacingUp, false);
            animator.SetBool(FacingDown, false);
        }
        else if (movement.y < 0)
        {
            animator.SetBool(FacingDown, true);
            animator.SetBool(FacingSide, false);
            animator.SetBool(FacingUp, false);
        }
        else if (movement.y > 0)
        {
            animator.SetBool(FacingUp, true);
            animator.SetBool(FacingSide, false);
            animator.SetBool(FacingDown, false);
        }

        var transformLocalScale = transform.localScale;
        transformLocalScale.x = movement.x != 0 ? movement.x : transformLocalScale.x;
        transform.localScale = transformLocalScale;
    }
}