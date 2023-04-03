using System.Collections;
using System.Collections.Generic;
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
        }

        if (health <= 0 && !isDead)
        {
            isDead = true;
            gameManager.GameOver();
            anim.SetTrigger("Death");
            // Destroy(gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {

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
