using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health =3;
    [SerializeField] int maxHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
    public void Damage(int damageAount){
        health -= damageAount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
