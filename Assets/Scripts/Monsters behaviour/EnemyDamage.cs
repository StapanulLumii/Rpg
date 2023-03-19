using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public KnightHealth knightHealth;
    public int damage = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            knightHealth.takeDamage(damage);
            Debug.Log("Player was attacked");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
