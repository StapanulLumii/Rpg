using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public GameObject gameObject;
    public Rigidbody2D rb;
    public int EnemySpeed = 2;
    public Transform curentPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        curentPoint = pointB.transform;
        transform.Rotate(0, 0, 0);

    }
    // Update is called once per frame
    void Update()
    {
        Vector2 point = curentPoint.position - transform.position;
        if(curentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(EnemySpeed,0);
        }
        else
        {
            rb.velocity = new Vector2(-EnemySpeed, 0);
        }

        if (Vector2.Distance(transform.position, curentPoint.position) < 0.5f && curentPoint == pointB.transform)
        {
            flip();
            curentPoint = pointA.transform;
            transform.Rotate(0, 0, 0);
        }

        if (Vector2.Distance(transform.position, curentPoint.position) < 0.5f && curentPoint == pointA.transform)
        {
            flip();
            curentPoint = pointB.transform;
            transform.Rotate(0, 0, 0);
        }
    }
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);

    }
}
