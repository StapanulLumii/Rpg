using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;

    [SerializeField] private GameObject blink;

    [SerializeField] private AudioSource takeDamage;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        blink.SetActive(false);

        //anim = GetComponent<Animator>();
    }
   private void EnableBlink()
    {
        takeDamage.Play();
        blink.SetActive(true);
    }
    private void DisableBlink()
    {
        blink?.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health < currentHealth)
        {
            Invoke("EnableBlink", 0f);
            Invoke("DisableBlink", 0.1f);
            currentHealth = health;
            //anim.SetTrigger("Hurt");
           
        }
        
        if (health <= 0)
        {
            takeDamage.Play();
            Destroy(gameObject);
            //anim.SetTrigger("Death");
           
        }
    }
}
