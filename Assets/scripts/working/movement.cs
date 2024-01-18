using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class movement : MonoBehaviour
{
    [SerializeField] private int speed = 50;
    private Vector2 move;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;
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
            animator.SetBool("IsWalking", false);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
