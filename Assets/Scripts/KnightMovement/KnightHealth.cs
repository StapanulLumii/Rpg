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
    private bool isNotBlocking;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
        isNotBlocking = true;
    }
    public void takeDamage(int amount)
    {
        health -= amount;
        if (health <= 0 && !isDead && isNotBlocking)
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
