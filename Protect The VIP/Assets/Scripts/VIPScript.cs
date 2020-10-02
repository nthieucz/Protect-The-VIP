﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIPScript : MonoBehaviour
{
    //Direction: Right = 1, Left = -1
    public int direction = 1;
    public int hitDirection = 1;
    public float movespeed;
    public float jumpForce;
    private Rigidbody2D rb;

    public Transform BottomRightCheck;
    public Transform TopRightCheck;
    public Transform BottomLeftCheck;
    public Transform TopLeftCheck;
    public LayerMask WhatAreObstacles;



    //Check and timer garbage
    private float timer;
    private float timerStart = 1;

    private float jumpTimer;
    private float jumpTimerStart = 2;

    private bool wasAlerted;



    

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
        wasAlerted = false;

        rb = gameObject.GetComponent<Rigidbody2D>();
        jumpTimer = jumpTimerStart;
        
    }

    private void Update()
    {

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
                if (!wasAlerted)
                {
                    //Alert()
                    wasAlerted = !wasAlerted;
                }
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (state == State.Walk)
        {

            if (collision.gameObject.layer == 8)
            {
                if (collision.gameObject.transform.position.x > gameObject.transform.position.x)
                {
                    Hit(1);
                }
                else
                {
                    Hit(-1);
                }
            }
        }
    }
    public void Check(int direction)
    {
        float distance = 0.5f;
        if (direction > 0)
        {
            RaycastHit2D bottomhit =  Physics2D.Raycast(BottomRightCheck.position, Vector2.right, distance, WhatAreObstacles);
            RaycastHit2D tophit = Physics2D.Raycast(TopRightCheck.position, Vector2.right, distance, WhatAreObstacles);
            
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
        Debug.Log("hit called with dir = " + dir);

    }

    public void Redirect()
    {
        wasAlerted = false;

        timer = 0;
        if (direction == hitDirection)
        {
            state = State.ChangeDirection;
        }
        else
        {
            state = State.Walk;
        }
    }

    public void Alert()
    {

    }
}
