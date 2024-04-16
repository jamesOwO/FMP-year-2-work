using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private bool moving = false;
    private bool startGame = false;
    private Rigidbody2D rb;
    public float moveSpeed;
    private float movehorizontal;
    private float jumpforce;
    private bool isjumping;
    private bool isRunning = false;

    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;

    public Animator cageAnimator;
    public Animator animator; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //moveSpeed = 7f;
        jumpforce = 10f;
        coll = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        if (moving == true)
        {
            movehorizontal = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(movehorizontal * moveSpeed, rb.velocity.y);

            if (movehorizontal > 0.1)
            {
                isRunning = true;
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (movehorizontal < -0.1)
            {
                isRunning = true;
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                isRunning = false;
            }
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && startGame == false)
        {
            startGame = true;
            cageAnimator.SetBool("Fall", false);
            Console.WriteLine("Spacebar down");
        }






        animator.SetBool("Running", isRunning);

    }
}
