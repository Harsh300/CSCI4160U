using UnityEngine;
using UnityEngine.UI;

public class Enemy: MonoBehaviour
{
    public int enemyHealth=100;
    public int currentEnemyHealth;
    private  PlayerController2D controller;

    private float timeSinceLastTurn;
    private float turnDuration = 6f;
    private float velocityX = -2f;

    private void Start()
    {
        timeSinceLastTurn = Time.time;
        controller = GetComponent<PlayerController2D>();
        currentEnemyHealth = enemyHealth;
    }

    private void Update()
    {
        if ((Time.time - timeSinceLastTurn) > turnDuration)
        {
            // turn
            velocityX *= -1f;

            // reset timer
            timeSinceLastTurn = Time.time;
        }

        controller.Move(velocityX * Time.deltaTime, false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        
    }
    public void TakeDamage(int damage)
    {
        currentEnemyHealth = currentEnemyHealth - damage;
        if (currentEnemyHealth <= 0)
        {
            Destroy(gameObject);

        }
        //playerHealthSlider.value = currentHealth;

    }
   
}