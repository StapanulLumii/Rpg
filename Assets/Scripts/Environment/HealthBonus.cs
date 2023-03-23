using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{

    KnightHealth knightHealth;
    public int healthBonus = 1;

    void Awake()
    {
        knightHealth = FindObjectOfType<KnightHealth>();    
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(knightHealth.health < knightHealth.maxHealth)
        {
            Destroy(gameObject);
            knightHealth.health = knightHealth.health + healthBonus;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
