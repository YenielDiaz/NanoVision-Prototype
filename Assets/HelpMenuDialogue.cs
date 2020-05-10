using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class HelpMenuDialogue : MonoBehaviour
{
    // Help menu parts
    public GameObject textBox;
    public GameObject choice1; //Information about general game
    public GameObject choice2; //Explanation of goals
    public GameObject choice3; //Hints for mini game
    public GameObject choice4; //Back to game option, handled by Unity

    //Text files where dialogue info will come from
    public TextAsset aboutGame;
    public TextAsset goalInfo;
    public TextAsset miniGameHints;

    //Arrays to hold all dialogue
    private string[] dialogue;
    private string[] dialogue1;
    private string[] dialogue2;
    private string[] dialogue3;

    //variable to keep track of array position
    private int count;  

    /**
     * A choice for each button assigned to menu. All options, when pressed, turn off buttons and
     * turn on text box. Each is assigned a respective text asset beforehand.
     **/
    public void ChoiceOption1()
    {
        ToggleOptions();
        dialogue = dialogue1;
        Dialogue();
    }

    public void ChoiceOption2()
    {
        ToggleOptions();
        dialogue = dialogue2;
        Dialogue();
    }

    public void ChoiceOption3()
    {
        ToggleOptions();
        dialogue = dialogue3;
        Dialogue();
    }

    //Takes text from asset files and saves them in string array by using new line delimiter
    void Start()
    {
        dialogue1 = aboutGame.text.Split(new[] {"\n" }, StringSplitOptions.None);
        dialogue2 = goalInfo.text.Split(new[] {"\n"}, StringSplitOptions.None);
        dialogue3 = miniGameHints.text.Split(new[] {"\n"}, StringSplitOptions.None);
    }

    //Takes dialogue (text asset) array of chosen option and traverses through it
    //If all information has been given, count variable is returned to beginning
    public void Dialogue()
    {
        if(count<dialogue.Length)
            textBox.GetComponentInChildren<Text>().text = dialogue[count++];
        else
        {
            ToggleOptions();
            textBox.SetActive(false);
            count = 0;
        }
    }

    //Switches between options and textbox by turning on/off activeness
    private void ToggleOptions()
    {
        textBox.SetActive(!textBox.activeSelf);
        choice1.SetActive(!choice1.activeSelf);
        choice2.SetActive(!choice2.activeSelf);
        choice3.SetActive(!choice3.activeSelf);
        choice4.SetActive(!choice4.activeSelf);
    }
}
