using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDialogueAppear : MonoBehaviour
{
    public GameObject dialogBox;
    // Start is called before the first frame update
    void Start()
    {
        
              
        if (dialogBox != null)
          {
          dialogBox.SetActive(true);
          }
         

          // Debug message to confirm that the dialog box is being displayed
          Debug.Log("Dialog box is displayed.");

          
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }
}
