using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public float tresholdY = -15f;

    [SerializeField] private GameObject blink;

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
            Debug.Log("enemy dead");
            Destroy(gameObject);
            //anim.SetTrigger("Death");
           
        }

        if (transform.position.y <= tresholdY)
        {
            Destroy(gameObject);
            Debug.Log("Monster destroyed");
        }
    }
}
