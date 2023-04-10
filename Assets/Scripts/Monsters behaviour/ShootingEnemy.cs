using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject Bullet;
    [SerializeField]
    float fireRate;
    float nextFire;
    void Start()
    {
        fireRate = 1f;
        nextFire = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
    }
    void CheckIfTimeToFire()
    {
        if(Time.deltaTime > nextFire)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            nextFire = Time.deltaTime + fireRate;
        }
    }
}
