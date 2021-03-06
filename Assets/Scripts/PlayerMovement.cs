﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    //Vector3 Mover = new Vector3(0.1f,0,0);

    Rigidbody2D myRigidBody;

    [SerializeField]
    float movementSpeed = 1;

    [SerializeField]
    float jumpStrength = 10;

    [SerializeField]
    Transform groundDetectPoint;

    [SerializeField]
    Transform ceilingDetectPoint;

    [SerializeField]
    float groundDetectRadius = .2f;

    [SerializeField]
    LayerMask whatCountsAsGround;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    Text coinCounter;

    private bool isOnGround;
    private bool isOnCeiling;
    private bool shouldJump = false;
    private float horizontalInput;

    private Vector2 jumpForce;

    bool facingRight = true;
    bool isUpsideDown = false;

    Animator anim;


    // Use this for initialization
    void Start()
    {
        Debug.Log("Called from Start.");
        //shouldJump = true;
        audioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
        jumpForce = new Vector2(0, jumpStrength);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        GetJumpInput();
        UpDateIsOnGround();
        UpDateIsOnCeiling();
        if (Input.GetButtonDown("Reset"))
        {
            transform.position =
                Checkpoint.currentlyActivatedCheckpoint.transform.position;
        }
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetFloat("vSpeed", Mathf.Abs(verticalMove));

        coinCounter.text = "Coins: " + Coin.coinCount;
        HandleMovement(move);
        HandleJump();

        //debugging
        //Debug.Log(isOnGround);
        //Debug.Log(isOnCeiling);
    }

    void HorizontalFlip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void VerticalFlip()
    {
        isUpsideDown = !isUpsideDown;
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
    }

	private void GetMovementInput()
	{
		horizontalInput = Input.GetAxis("Horizontal");
	}

	private void GetJumpInput()
	{
		if (Input.GetButtonDown("Jump") && (isOnGround || isOnCeiling))
		{
			shouldJump = true;
		}
	}

    private void UpDateIsOnGround()
    {
        Collider2D[] groundObjects = Physics2D.OverlapCircleAll(groundDetectPoint.position, groundDetectRadius, whatCountsAsGround);
        isOnGround = groundObjects.Length > 0;
        

        //debugging
       // if (isOnGround)
            //Debug.Log("Should Jump");
    }

    private void UpDateIsOnCeiling()
    {
        Collider2D[] groundObjects = Physics2D.OverlapCircleAll(ceilingDetectPoint.position, groundDetectRadius, whatCountsAsGround);
        isOnCeiling = groundObjects.Length > 0;

        //debugging
        //if (isOnCeiling)
           // Debug.Log("Should Jump");

    }

    private void HandleJump()
    {
        

		if (shouldJump)
        {
            //myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpStrength);
            Physics2D.gravity = Physics2D.gravity * (-1);
            audioSource.Play();
            VerticalFlip();
            //myRigidBody.AddForce(jumpForce);
            isOnGround = false;
            isOnCeiling = false;
			shouldJump = false;
        }
    }

    private void HandleMovement(float move)
    {

        // Debug.Log("Horizontal Input: " + horizontalInput);

        myRigidBody.velocity = new Vector2(horizontalInput * movementSpeed, myRigidBody.velocity.y);

        if (move > 0 && !facingRight)
            HorizontalFlip();
        else if (move < 0 && facingRight)
            HorizontalFlip();

    }

    /*
    public void CheckReset()
    {
        if(Input.GetKeyDown("KeyCode.R"))
        {
            transform.position =
                Checkpoint.currentlyActivatedCheckpoint.transform.position;
        }
    }
    */
}
