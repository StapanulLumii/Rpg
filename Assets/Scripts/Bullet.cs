using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 1f;

    private Rigidbody2D rb;
    private HeroKnight target;
    Vector2 moveDirection;

    private KnightHealth knightHealth;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<HeroKnight>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        //rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        rb.velocity = moveDirection * moveSpeed;
        
        Destroy(gameObject, 2f);
    }
    
    void Update()
    {
        
    }
}