using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 1f;

    private Rigidbody2D rb;
    private HeroKnight target;
    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<HeroKnight>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        //rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        rb.velocity = moveDirection * moveSpeed;
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //if(collider.gameObject.CompareTag("Player"))
        
            Debug.Log("Hit!");
            Destroy(gameObject);
       

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
