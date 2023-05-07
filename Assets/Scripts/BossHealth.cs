using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth =10f;

    private Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
    
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Update()
    {
        if (currentHealth < maxHealth)
        {
            // Invoke("EnableBlink", 0f);
            // Invoke("DisableBlink", 0.1f);
            currentHealth = maxHealth;
            animator.SetTrigger("Hurt");
           
        }
        
        if (currentHealth <= 0)
        {
            // takeDamage.Play();
            Die();
        }
    }
    private void Die()
    {
        // Play death animation
        animator.SetBool("isRunning", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isDead", true);

        // Disable movement and collider
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Collider2D>().enabled = false;

        // Destroy the game object after a delay
        //Destroy(gameObject, 2f);
    }
}