using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDialogDisappear : MonoBehaviour
{
    public GameObject dialogBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            dialogBox.SetActive(false);
            //Destroy(gameObject, 5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
