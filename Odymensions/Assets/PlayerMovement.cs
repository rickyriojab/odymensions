using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool isLeft = false;
    bool isRight = false;
    bool isJump = false;

    public Rigidbody2D rigidBody2D;
    public float speedForce;
    public float jumpForce;

    public void clickLeft()
    {
        isLeft = true;
    }

    public void releaseLeft()
    {
        isLeft = false;
    }

    public void clickRight()
    {
        isRight = true;
    }

    public void releaseRight()
    {
        isRight = false;
    }

    public void clickJump()
    {
        isJump = true;
    }

    private void FixedUpdate()
    {
        if (isLeft)
        {
            rigidBody2D.AddForce(new Vector2(-speedForce, 0) * Time.deltaTime);
        }

        if (isRight)
        {
            rigidBody2D.AddForce(new Vector2(speedForce, 0) * Time.deltaTime);
        }
    }
}
