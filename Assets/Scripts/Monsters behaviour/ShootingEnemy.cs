using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject Bullet;
    [SerializeField]
    float fireRate;
    float nextFire;
    public Transform bulletPos;
    private float timer;
    void Start()
    {
        fireRate = 1f;
        nextFire = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > nextFire) 
        {
            timer = 0f;
            nextFire = Time.deltaTime + fireRate;
            CheckIfTimeToFire();
        }
    }
    void CheckIfTimeToFire()
    {
        Instantiate(Bullet, bulletPos.position, Quaternion.identity);
    }
}