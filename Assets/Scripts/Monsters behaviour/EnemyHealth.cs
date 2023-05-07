using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public bool IsNotBoss =  true;

    [SerializeField] private GameObject blink;

    [SerializeField] private AudioSource takeDamage;
    private Animator animator;
    private Animator anim;

    public HealBarScript healthBar; 
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        blink.SetActive(false);

        anim = GetComponent<Animator>();
        if (!IsNotBoss)
        {
            healthBar.SetMaxHealth(health);
        }
    }
   private void EnableBlink()
    {
        takeDamage.Play();
        blink.SetActive(true);
    }
    private void DisableBlink()
    {
        blink?.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health < currentHealth)
        {
            if (IsNotBoss)
            {
                Invoke("EnableBlink", 0f);
                Invoke("DisableBlink", 0.1f);
                currentHealth = health;
            }
            else
            {
                currentHealth = health;
                healthBar.SetHealth(currentHealth);
                anim.SetTrigger("Hurt");
            }
        }
        
        if (health <= 0)
        {
            if (IsNotBoss)
            {
                
            takeDamage.Play();
            Destroy(gameObject);
            //anim.SetTrigger("Death");
            }
            else
            {
                Die();
            }
           
        }
    }
    private void Die()
    {
        // Play death animation
        anim.SetBool("isRunning", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isDead", true);

        // Disable movement and collider
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<BossAI>().enabled = false;

        // Destroy the game object after a delay
        //Destroy(gameObject, 2f);
    }
}
