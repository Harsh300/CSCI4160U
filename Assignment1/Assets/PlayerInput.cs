using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{


    // Variables 
    public float runSpeed = 40f;

    private PlayerController2D controller;
    private Animator animator;

    private float horizontalMove = 0f;
    private bool jump = false;


    private void Start()
    {

        // Get Componenents
        controller = GetComponent<PlayerController2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        // Horzonital Movement in direction of x
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Click Button to Jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }


        // Get Animator Parameters
        animator.SetFloat("Speed", controller.speed);
        animator.SetBool("IsJumping", !controller.isGrounded);

    }

    void FixedUpdate()
    {
        // Move PLayer
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
