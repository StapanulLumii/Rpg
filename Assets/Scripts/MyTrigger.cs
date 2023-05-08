using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTrigger : MonoBehaviour
{
    public GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            healthBar.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
