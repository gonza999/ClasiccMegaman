using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2D;
    public float speed = 10;
    bool walk = false;
    bool fall = false;
    public static bool down = false;
    bool shoot = false;
    bool jump = false;
    float x = 0;
    float y = 0;
    int timeJump = 0;
    public float jumpForce = 5f;
    public int limitJump = 10;
    bool charge = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           animator.SetBool("Shoot", true);
        }
        animator.SetBool("Walk", walk);
        animator.SetBool("Down", down);
        animator.SetBool("Jump", jump);
        animator.SetBool("Fall", fall);
    }
    private void FixedUpdate()
    {
        y = Input.GetAxisRaw("Vertical");
        x = Input.GetAxisRaw("Horizontal");
        Down();
        if (!down)
        {
            RightAndLeft();
            Jump();
        }
        if (CheckGround.isGrounded)
        {
            fall = false;
            jump = false;
            timeJump = 0;
        }
        else if (!CheckGround.isGrounded && timeJump==0)
        {
            fall = true;
        }
    }
    private void Jump()
    {
        if (y > 0 && !fall)
        {
            if (timeJump < limitJump)
            {
                timeJump++;
                jump = true;
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            }
            else
            {
                fall = true;
            }
        }
        else if (y <= 0)
        {
            fall = true;
        }
    }
    private void Down()
    {
        if (y < 0)
        {
            down = true;
        }
        else
        {
            down = false;
        }
    }
    private void RightAndLeft()
    {
        if (x > 0)
        {
            walk = true;
            spriteRenderer.flipX = false;
            rigidbody2D.velocity = Vector2.right * Time.deltaTime * speed;
        }
        if (x < 0)
        {
            spriteRenderer.flipX = true;
            walk = true;
            rigidbody2D.velocity = Vector2.left * Time.deltaTime * speed;
        }
        if (x == 0)
        {
            walk = false;
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}
