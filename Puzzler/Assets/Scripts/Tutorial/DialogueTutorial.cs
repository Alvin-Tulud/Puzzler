using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Ink.Runtime;

public class DialogueTutorial : MonoBehaviour
{
    public GameObject textbox; //tangible text box element
    public TextMeshProUGUI actualText; //tangible text element

    private Story thisStory; //current story we will play
    private bool isPlaying; //whether or not the story is playing yet

    public GameObject[] dialogueChoices; //two boxes which contain the text of the choices
    public TextMeshProUGUI[] choicetexts; //two tangible text elements to display the options

    private float displaySpeed = 0.03f; //speed at which the text will scroll
    private Coroutine existCheck; //checks if the coroutine exists
    public bool lineFinish = true; //whether or not the line has finished printing

    private bool writing = false; 
    private bool done = true;

    private GameObject textManager;


    private bool oneClick = false;

    // Start will find the dialogue manager and set it to be playing.
    //will make all items invisible from the start.
    void Start() 
    {
        textManager = GameObject.Find("dialogueManager");
        isPlaying = false; 
        textbox.SetActive(false);

        for (int i = 0; i < choicetexts.Length; i++)
        {
            choicetexts[i] = choicetexts[i].GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            if (lineFinish)
            {
                if (thisStory.canContinue)
                {
                    //actualText.text = thisStory.Continue();

                    if (existCheck != null)
                    {
                        StopCoroutine(existCheck);
                    }

                    existCheck = StartCoroutine(printLine(thisStory.Continue()));

                    Debug.Log("TEXT OG: " + actualText.text);
                    showChoices();
                }
                else
                {
                    isPlaying = false;
                    textbox.SetActive(false);
                    actualText.text = "";
                }
            }
        }

        
    }

    public void enterDialogue(TextAsset textInput)
    {
        thisStory = new Story(textInput.text);
        isPlaying = true;
        textbox.SetActive(true);

        if (lineFinish)
        {
            if (thisStory.canContinue)
            {
                //actualText.text = thisStory.Continue();

                if (existCheck != null)
                {
                    StopCoroutine(existCheck);
                }

                existCheck = StartCoroutine(printLine(thisStory.Continue()));


                showChoices();
            }
            else
            {
                Debug.Log("SOTRY IS FINISHED");
                isPlaying = false;
                textbox.SetActive(false);
                actualText.text = "";
                
            }
        }
        
    }

    private void setSpeed(string lineInput)
    {
        if (lineInput.Length > 100)
        {
            displaySpeed = 0.02f;
        }
        else if (lineInput.Length <= 100 && lineInput.Length > 50)
        {
            displaySpeed = 0.022f;
        }
        else
        {
            displaySpeed = 0.025f;
        }
    }


    private IEnumerator printLine(string lineInput)
    {
        //writing = true;
        //done = false;

        //set the displayed text to be empty
        actualText.text = "";

        //set the speed of the text
        setSpeed(lineInput);

        lineFinish = false;

        //show the text one letter at a time
        foreach (char letter in lineInput.ToCharArray())
        {

            if (Input.GetMouseButton(1))
            {
                actualText.text = lineInput;
                break;
            }

            actualText.text += letter;
            yield return new WaitForSeconds(displaySpeed);
            
        }

        //Debug.Log("finished like normal");
        lineFinish = true;
        done = true;
    }


    private void showChoices()
    {
        List<Choice> currentChoices = thisStory.currentChoices;

        //this section resets the buttons and text
        choicetexts[0].text = "";
        choicetexts[1].text = "";

        for (int i = 0; i < dialogueChoices.Length; i++)
        {
            dialogueChoices[i].gameObject.SetActive(false);
        }

        if (currentChoices.Count > dialogueChoices.Length)
        {
            Debug.Log("BAAAAAH TOO MANY CHOCIE");
        }

        //this section will set the buttons to active and display the text of the choices on them
        int ind = 0;
        foreach (Choice choice in currentChoices)
        {
            dialogueChoices[ind].gameObject.SetActive(true);

            choicetexts[ind].text = currentChoices[ind].text;

            ind++;
        }

    }

    public void chosenOpt(int choiceNum)
    {
        thisStory.ChooseChoiceIndex(choiceNum);
    }

}