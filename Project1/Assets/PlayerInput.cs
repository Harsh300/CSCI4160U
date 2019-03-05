using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInput : MonoBehaviour
{
    public Slider playerHealthSlider;
    public int health = 100;
    public int currentHealth;

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
        currentHealth = health;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //playerHealthSlider.value -= 10;
            TakeDamagePlayer(10);
            Debug.Log("Ouch!");
        }

    }
    public void TakeDamagePlayer(int damage)
    {
        currentHealth = currentHealth - damage;
        playerHealthSlider.value = currentHealth;

    }
    void FixedUpdate()
    {
        // Move PLayer
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
