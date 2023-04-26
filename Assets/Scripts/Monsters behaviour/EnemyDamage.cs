using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public KnightHealth knightHealth;
    public int damage = 1;
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        knightHealth = collision.gameObject.GetComponent<KnightHealth>();
        
        if(collision.gameObject.tag == "Player")
        {
            knightHealth.takeDamage(damage);
            Debug.Log("Player was attacked");
        }
    }
    
    void Update()
    {
        
    }
}
