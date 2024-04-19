using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private bool canPaus = true;
    public bool menuActive = false;

    private double gameStart = 0;
    private bool startGame = false;

    private bool moving = false;
    public float moveSpeed;
    private float movehorizontal;
    private float jumpforce;
    private bool isjumping;
    private bool isRunning = false;

    public GameObject pauseMenu;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    public SpriteRenderer playerSprite;
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
        if (menuActive == false)
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
    }
    private void Update()
    {
        if (menuActive == false)
        {

            animator.speed = 1f;
            if (Input.GetButtonDown("Jump") && startGame == false)
            {
                startGame = true;
                cageAnimator.SetBool("Fall", true);
                Console.WriteLine("Spacebar down");
                gameStart = Time.time + 2.6;
            }
            if (startGame == true && Time.time > gameStart)
            {
                moving = true;
                playerSprite.enabled = true;
            }

        }

        if (menuActive == true)
        {
            animator.speed = 0f;
            //cageAnimator.speed = 0f;
        }

        if (Input.GetKeyDown(KeyCode.P) && canPaus == true)
        {
            if (menuActive == false)
            {
                menuActive = true;
                pauseMenu.SetActive(true);

            }
        }
        

        animator.SetBool("Running", isRunning);

    }
}
