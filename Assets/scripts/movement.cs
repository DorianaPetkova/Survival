using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    [SerializeField] private int speed = 120;
    private Vector2 move;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] private float maxSkyHeight = 106;  // Set your maximum sky height here

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value)
    {
        move = value.Get<Vector2>();
        if (move.x != 0 || move.y != 0)
        {
            animator.SetFloat("X", move.x);
            animator.SetFloat("Y", move.y);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {
        // Move the character
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

        // Check sky boundary
        if (transform.position.y > maxSkyHeight)
        {
            // Clamp the character's position to stay within the sky boundary
            Vector3 newPosition = transform.position;
            newPosition.y = maxSkyHeight;
            transform.position = newPosition;
        }
    }
}
