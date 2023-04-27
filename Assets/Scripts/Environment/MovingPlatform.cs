using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform posA, posB;
    public int Speed;
    Vector2 targePos;
    // Start is called before the first frame update
    void Start()
    {
        targePos = posB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, posA.position) < .1f) targePos = posB.position;

        if (Vector2.Distance(transform.position, posB.position) < .1f) targePos = posA.position;

        transform.position = Vector2.MoveTowards(transform.position, targePos, Speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.transform.SetParent(null);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(posA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(posB.transform.position, 0.5f);
        Gizmos.DrawLine(posA.transform.position, posB.transform.position);

    }
}
