using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;  
    }
    


    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
       Debug.Log("Name: "+hitInfo.name);
       Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(50);
            Debug.Log("DAMAGE");
            Destroy(gameObject);
        }
        Destroy(gameObject,1.8f);

    }
}
