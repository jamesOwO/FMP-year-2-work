using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    private float movehorizontal;
    private float jumpforce;
    private bool isjumping;
    private bool isRunning = false;

    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;

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
    private void Update()
    {
        animator.SetBool("Running", isRunning);

    }
}
