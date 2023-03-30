using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;


public class KnightHealth : MonoBehaviour
{
    public int health = 3;
    public int maxHealth = 10;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;
    public GameManagerScipt gameManager;
    private bool isDead;
    private Animator anim;
    public float tresholdY = -10f;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        health = maxHealth;
    }
    public void takeDamage(int amount)
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Block"))
        {
            health -= amount;
            Debug.Log("aloha");
            anim.SetTrigger("Hurt");
        }

        if (health <= 0 && !isDead)
        {
            isDead = true;
            gameManager.GameOver();
            anim.SetTrigger("Death");
        }
    }

    private void FallDown()
    {
        if (transform.position.y <= tresholdY)
        {
            anim.SetTrigger("Death");
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }
    
    void Update()
    {
        FallDown();
        
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }
    }
   
}
