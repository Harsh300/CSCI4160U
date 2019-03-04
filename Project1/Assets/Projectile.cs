using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    public Rigidbody2D rb;
 
    void Start()
    {
        rb.velocity = transform.right * speed;  
    }
    


    private void onTriggerEnter2D(Collider2D colllider)
    {
        debug.Log("Destroyed object");
        Destroy(gameObject);
    }
}
