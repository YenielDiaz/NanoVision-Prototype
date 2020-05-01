using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //cached component
    TextMeshProUGUI tmpro;

    //cached object
    InteractionCanvas canvas;

    [SerializeField] string filename = "example1";
    [SerializeField] float txtSpeed = 0.1f;
    TextAsset txt;

    //array to store sentences
    public string[] sentences;
    private int currIndex;


    // Start is called before the first frame update
    void Start()
    {
        //get canvas with the script interactionCanvas
        canvas = FindObjectOfType<InteractionCanvas>();
        //get this object's text mesh pro component
        tmpro = GetComponent<TextMeshProUGUI>();
        //load text file from the resources folder. Has to be from the resources folder
        txt = Resources.Load("TextFiles/" + filename) as TextAsset;

        //get all sentences by splitting the text wherever a period is found
        //this will end up with one empty sentences at the end will have to deal with that
        sentences = txt.text.Split('.'); //WE WILL HAVE TO BE CAREFUL WITH ABREVIATIONS OR FIND A WAY TO DEAL WITH THEM

        //start index at second position because we will show the first one on instantiation
        currIndex = 1;
        //on creation show first sentence
        StartCoroutine(ShowText(sentences[0]));
        

    }

    //Coroutine to show next char sequentially
    IEnumerator ShowText(string text)
    {
        //first it is empty
        tmpro.text = "";
        //for each loop
        foreach(char c in text.ToCharArray())
        {
            //show next char
            tmpro.text += c;
            //wait txtSpeed amount of seconds before showing next char
            yield return new WaitForSeconds(txtSpeed);
        }
    }

    //method the button will call whenever it is pressed
    public void showNextSentence()
    {
        StopAllCoroutines();
        int size = sentences.Length;

        //Destroy box if the last sentence was shown
        if (currIndex >= size-1) //we use size - 1 because when we store all the sentences with split there is always one empty sentence at the end
        {
            canvas.DestroyBox();
        }
        //otherwise show next sentence in the sentences array
        else
        {
            StartCoroutine(ShowText(sentences[currIndex]));
            currIndex++;
        }
        
        
    }
}
