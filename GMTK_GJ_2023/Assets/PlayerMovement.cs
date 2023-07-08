using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float jumpStr = 100f;
    private bool isFacingRight = true;

    private string command = "idle";
    private bool isMoving = false;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    public Transform playerTransform;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            command = "right";
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            command = "left";
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            command = "jumpUp";
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            command = "jumpRight";
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            command = "jumpLeft";
        }
        if (Math.Abs(Input.GetAxisRaw("Horizontal")) == 1f && Math.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        {
            rb.velocity = new Vector2(0f, Time.deltaTime * jumpStr);
            rb.velocity = new Vector2(Time.deltaTime * moveSpeed, 0f);
        }
    }

    void FixedUpdate()
    {
        if (!isMoving)
        {
            switch (command)
            {
                case "right":
                    rb.velocity = new Vector2(Time.deltaTime * moveSpeed, 0f);
                    isFacingRight = true;
                    isMoving = true;
                    StartCoroutine(WaitCommand());
                    break;

                case "left":
                    rb.velocity = new Vector2(Time.deltaTime * -moveSpeed, 0f);
                    isFacingRight = false;
                    isMoving = true;
                    StartCoroutine(WaitCommand());
                    break;

                case "jumpUp":
                    rb.velocity = new Vector2(0f, Time.deltaTime * jumpStr);
                    isMoving = true;
                    StartCoroutine(WaitCommand());
                    break;

                case "jumpRight":
                    rb.velocity = new Vector2(Time.deltaTime * moveSpeed * 0.8f, Time.deltaTime * jumpStr);
                    isFacingRight = true;
                    isMoving = true;
                    StartCoroutine(WaitCommand());
                    break;

                case "jumpLeft":
                    rb.velocity = new Vector2(Time.deltaTime * -moveSpeed * 0.8f, Time.deltaTime * jumpStr);
                    isFacingRight = false;
                    isMoving = true; 
                    StartCoroutine(WaitCommand());
                    break;
            }
        }
        
        command = "idle";
    }

    private IEnumerator WaitCommand()
    {
        yield return new WaitForSeconds(1.5f);
        isMoving = false;

    }

    public void moveRight()
    {
        command = "right";
    }

    public void moveLeft()
    {
        command = "left";
    }

    public void jumpRight()
    {
        command = "jumpRight";
    }

    public void jumpLeft()
    {
        command = "jumpLeft";
    }
}

