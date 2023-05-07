using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public Transform playerTransform;
    private Animator animator;
    private Rigidbody2D rb;
    public float chaseDistance;
    public float moveSpeed;
    private Vector2 directionToPlayer;
    
    //Attack
    public float attackDistance = 2f;
    private float timeSinceLastAttack;
    public float attackRange = 0.5f;
    public float attackDelay = 4f;
    public Transform attackPoint;
    public LayerMask attackLayers;
    
    public KnightHealth knightHealth;
    public int damage = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPLayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPLayer < chaseDistance)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        
       
    }

    private void FixedUpdate()
    {
        if (animator.GetBool("isRunning")) {
            directionToPlayer = (playerTransform.position - transform.position).normalized;
            directionToPlayer.y = 0;
            Vector2 newPosition = rb.position + directionToPlayer * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
            Flip();
            Attack();
        }
    }

    private void Flip()
    {
        // Flip the sprite if moving left
        if (directionToPlayer.x < 0)
        {
            transform.localScale = new Vector2(-1.5f, 1.5f);
        }
        // Flip the sprite back if moving right
        else if (directionToPlayer.x > 0)
        {
            transform.localScale = new Vector2(1.5f, 1.5f);
        }
    }
    private void Attack()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        
        if (distanceToPlayer <= attackDistance && timeSinceLastAttack >= attackDelay)
        {
            animator.SetTrigger("Attack");

            // Detect enemies within the attack range
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, attackLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<BossHealth>().TakeDamage(damage);
            }
            timeSinceLastAttack = 1f;
        }
        else
        {
            animator.SetBool("isRunning", true);
            timeSinceLastAttack += Time.fixedDeltaTime;
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    
    public void DealDamageToPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer <= attackDistance)
        {
            knightHealth.TakeDamage(damage);
        }
    }

}
