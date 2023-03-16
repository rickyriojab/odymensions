using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool isLeft = false;
    [SerializeField] private bool isRight = false;
    private bool isJump = false;
    private bool canJump = true;

    public Rigidbody2D rigidBody2D;
    public float speedForce;
    public float jumpForce;
    public float waitJump = 2.0f;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public void ClickLeft()
    {
        isLeft = true;
    }

    public void ReleaseLeft()
    {
        isLeft = false;
    }

    public void ClickRight()
    {
        isRight = true;
    }

    public void ReleaseRight()
    {
        isRight = false;
    }

    public void ClickJump()
    {
        isJump = true;
    }

    private void FixedUpdate()
    {
        if (isLeft)
        {
            rigidBody2D.AddForce(new Vector2(-speedForce, 0) * Time.deltaTime);
            spriteRenderer.flipX = true;
        }

        if (isRight)
        {
            rigidBody2D.AddForce(new Vector2(speedForce, 0) * Time.deltaTime);
            spriteRenderer.flipX = false;
        }

        if (isLeft || isRight) 
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);

        }

        if (isJump & canJump)
        {
            isJump = false;
            //fuerza en vector (x,y)
            rigidBody2D.AddForce(new Vector2(0, jumpForce));
            canJump = false;
            Invoke("WaitToJump", waitJump);
        }
    }

    private void WaitToJump()
    {
        canJump = true;
    }
}

