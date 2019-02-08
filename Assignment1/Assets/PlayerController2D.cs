using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController2D : MonoBehaviour
{


    // Variables 

    [Header("General")]
    [SerializeField] private float movementSpeed = 10f;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    [SerializeField] private LayerMask groundLayers;
    public float speed = 0.0f;

    [Header("Jumping")]
    [SerializeField] private bool canAirControl = true;
    [SerializeField] private float jumpForce = 500f;
    [SerializeField] private Transform groundPosition;
    public bool isGrounded;



    private bool isFacingRight = true;

    const float groundedRadius = .2f;
    const float ceilingRadius = .2f;

    private Rigidbody2D rigidBody;
    private Vector3 velocity = Vector3.zero;

    [Header("Events")]
    public UnityEvent OnLandEvent;




    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }


    }


    private void FixedUpdate()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        // Find any ground layer colliders closer than the ground position
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundPosition.position, groundedRadius, groundLayers);

        Debug.Log("Overlapping colliders: " + colliders.Length);

        for (int i = 0; i < colliders.Length; i++)
        {

            // If any of the colliders are not the object iself, it must be the ground
            if (colliders[i].gameObject != gameObject)
            {
                // Grounded
                isGrounded = true;

                // Not Grounded
                if (!wasGrounded)
                {
                    OnLandEvent.Invoke();
                }
            }
        }
    }


    // Moving and Jumping
    public void Move(float move, bool jump)
    {


        // Control the player if grounded or canAirControl is turned on
        if (isGrounded || canAirControl)
        {



            Vector3 targetVelocity = new Vector2(move * movementSpeed, GetComponent<Rigidbody2D>().velocity.y);

            // Smoothing to the speed
            rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, movementSmoothing);


            // Getting the speed
            speed = rigidBody.velocity.magnitude;

            if (move > 0 && !isFacingRight)
            {

                // Flip the sprite horizontally when going right
                Flip();
            }
            else if (move < 0 && isFacingRight)
            {
                // Flip the sprite horizontally when going left
                Flip();
            }
        }
        if (isGrounded && jump)
        {

            // add a vertical force to the player
            isGrounded = false;
            rigidBody.AddForce(new Vector2(0f, jumpForce));
        }
    }

    // Flipping player depending if moving left or run
    private void Flip()
    {
        // remember which way the sprite is facing
        isFacingRight = !isFacingRight;

        // multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }



}
