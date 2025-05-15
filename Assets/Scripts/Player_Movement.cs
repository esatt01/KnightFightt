using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float input;
    public float MoveSpeed;
    public float JumpForce;
    public bool canMove;
    public float nexttimetoAttack;
    public float Interval;
    public int yon;


    Animator anim;
    Rigidbody2D rb;

    public float boostedSpeed; 
    private float originalSpeed;
    private float boostTimer = 0f; 
    public float boostDuration = 5f; 

    public GameObject groundedcheck;
    public LayerMask Ground;
    public LayerMask enemy;
    public bool isGrounded;

    void Start()
    {
        yon = 1;
        canMove = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        originalSpeed = MoveSpeed;
    }

    void Update()
    {
        Turn();
        CallMovement();
        JumpPlayer();

        if (boostTimer > 0)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer <= 0)
            {
                MoveSpeed = originalSpeed;  // Eski haline döndür
            }
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(input * MoveSpeed, rb.velocity.y);
    }



    public void CallMovement()
    {
        if (canMove)
        {

            input = Input.GetAxis("Horizontal");
        }
        else
        {
            input = 0;
        }
        anim.SetFloat("Move", input);
    }


    public void Turn()
    {
        if (input < 0)
        {
            yon = -1;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (input > 0)
        {
            yon = 1;
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
    }


    public void JumpPlayer()
    {
        if (Physics2D.OverlapCircle(groundedcheck.transform.position, 0.2f, Ground))
        {
            isGrounded = true;
            anim.SetBool("isGrounded", true);
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("Jump");
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + JumpForce);
            }
        }
        else
        {
            isGrounded = false;
            anim.SetBool("isGrounded", false);
        }
    }

    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(new Vector2(transform.position.x, transform.position.y-0.6f), new Vector2(yon, 0));
        Gizmos.DrawSphere(new Vector2(transform.position.x + yon, transform.position.y - 0.8f), 1f);
    }

    public void ActivateSpeedBoost(float duration)
    {
        MoveSpeed = originalSpeed + boostedSpeed;
        boostTimer = duration;
    }



}
