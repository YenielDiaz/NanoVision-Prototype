using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCanvas : MonoBehaviour
{

    [SerializeField] Object uiElemPrefab;
    [SerializeField] float elemXPos = 15.4f;
    [SerializeField] float elemtYpos = 78.2f;
    private Object currentDialogueBox;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Function that will show the dialogue box when called
    public void ShowBox()
    {
        //We store the instantiated object in a global variable for accesibility
        //We ensure that there is only ever one currentDialogue box with the following if statement
        if(currentDialogueBox == null)
        {
            currentDialogueBox = Instantiate(uiElemPrefab, transform); //Will want to change this up so that it instantiates exactly where I want it to
        }
        
    }

    //Function that will destroy the dialogue box when called
    public void DestroyBox()
    {
        Destroy(currentDialogueBox);
        currentDialogueBox = null;
    }
}
