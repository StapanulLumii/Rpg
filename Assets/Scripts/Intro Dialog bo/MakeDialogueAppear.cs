using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDialogueAppear : MonoBehaviour
{
    public GameObject dialogBox;
    // Start is called before the first frame update
    void Start()
    {
        //if (dialogBox != null)
        //  {
        //  dialogBox.SetActive(true);
        //  }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogBox.SetActive(true);
            //Destroy(gameObject, 5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
