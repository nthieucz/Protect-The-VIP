using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIPScript : MonoBehaviour
{
    //Direction: Right = 1, Left = -1
    public int direction = 1;
    private int hitDirection = 1;
    public float movespeed;
    public float jumpForce;
    private Rigidbody2D rb;

    public Transform BottomRightCheck;
    public Transform TopRightCheck;
    public Transform BottomLeftCheck;
    public Transform TopLeftCheck;

    private float timer;
    private float timerStart = 1;

    private float jumpTimer;
    private float jumpTimerStart = 2;

    public LayerMask WhatAreObstacles;

    public State state = State.Walk;

    public enum State
    {
        Walk,
        Alert,
        ChangeDirection,
        Jump,
        Ragdoll,
        Recover

    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        jumpTimer = jumpTimerStart;
        
    }

    void FixedUpdate()
    {

        jumpTimer += Time.deltaTime;

        switch (state)
        {
            case State.Walk:
                Walk();
                //if conditions to change state
                Check(direction);
                break;
            case State.Alert:
                timer += Time.deltaTime;
                if (timer >= timerStart)
                {
                    Redirect();
                }

                break;
            case State.ChangeDirection:
                ChangeDirection();
                state = State.Walk;
                break;
            case State.Jump:
                Jump();
                state = State.Walk;
                break;
            case State.Ragdoll:
                if (rb.velocity == new Vector2(0,0))
                {
                    state = State.Recover;
                }
                break;
            case State.Recover:
                //Recover()
                state = State.Walk;
                break;
        }
    }

    public void Walk()
    {
        rb.velocity = new Vector2(movespeed * direction, rb.velocity.y);
    }


    public void ChangeDirection()
    {
        direction = -direction;
    }

    public void Jump()
    {
        if (jumpTimer >= jumpTimerStart)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jumpTimer = 0;
        }
        
    }

    public void Check(int direction)
    {
        float distance = 0.5f;
        if (direction > 0)
        {
            RaycastHit2D bottomhit =  Physics2D.Raycast(BottomRightCheck.position, Vector2.right, distance, WhatAreObstacles);
            RaycastHit2D tophit = Physics2D.Raycast(TopRightCheck.position, Vector2.right, distance, WhatAreObstacles);
            Debug.DrawRay(TopRightCheck.position, Vector2.right);

            if (bottomhit.collider != null && tophit.collider != null)
            {
                state = State.ChangeDirection;
            }
            else if(bottomhit.collider != null && tophit.collider == null)
            {
                state = State.Jump;
            }

        }
        else if (direction < 0)
        {
            RaycastHit2D bottomhit = Physics2D.Raycast(BottomLeftCheck.position, Vector2.left, distance, WhatAreObstacles);
            RaycastHit2D tophit = Physics2D.Raycast(TopLeftCheck.position, Vector2.left, distance, WhatAreObstacles);

            if (bottomhit.collider != null && tophit.collider != null)
            {
                state = State.ChangeDirection;
            }
            else if (bottomhit.collider != null && tophit.collider == null)
            {
                state = State.Jump;
            }
        }
    }

    public void Hit(int dir)
    {
        hitDirection = dir;
        state = State.Alert;
    }

    public void Redirect()
    {
        if (direction == hitDirection)
        {
            state = State.ChangeDirection;
        }
        else
        {
            state = State.Walk;
        }
    }
}
