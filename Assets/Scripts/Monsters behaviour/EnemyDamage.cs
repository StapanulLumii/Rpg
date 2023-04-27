using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public KnightHealth knightHealth;
    public int damage = 1;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            knightHealth.takeDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
