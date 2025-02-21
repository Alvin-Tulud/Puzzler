using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Ink.Runtime;

public class DialogueTutorial : MonoBehaviour
{
    public GameObject textbox; //tangible text box element

    //Arrows to be displayed in tandem with the dialogue

    //CHANGE THIS TO A LIST OR ARRAY
    public GameObject arrow1, arrow2, arrow3, arrow4, arrow5, arrow6, arrow7, arrow8, arrow9, arrow10;
    public GameObject resetButton, exitButton;
    public GameObject hekks1, hekks2, hekks3;

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
        //ONCE YOU GET THE LIST USE A FOREACH TO GO THROUGH EACH ELEMENT
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        arrow3.SetActive(false);
        arrow4.SetActive(false);
        arrow5.SetActive(false);
        arrow6.SetActive(false);
        arrow7.SetActive(false);
        arrow8.SetActive(false);
        arrow9.SetActive(false);
        arrow10.SetActive(false);

        resetButton.SetActive(false);
        exitButton.SetActive(false);

        hekks2.SetActive(false);
        hekks3.SetActive(false);

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

        if (Input.GetMouseButtonDown(0))
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

        //this is the section of swaps for all of the hekks emotes:
        if (lineInput.Contains("I would've believed you if you weren't wearing an ")
            || lineInput.Contains("like I'll be the one giving you the training")
            || lineInput.Contains("That's where you come in")
            || lineInput.Contains("got me here to teach you the ropes after")
            || lineInput.Contains("you can find me in the top right corner of the screen!")
            || lineInput.Contains("Anyways, that should cover most of the basics for ya")
            )
        {
            hekks3.SetActive(true);
            hekks1.SetActive(false);
        }
        else
        {
            hekks1.SetActive(true);
            hekks3.SetActive(false);
        }


        if (lineInput.Contains("It'd be a great day to go fishing")
            || lineInput.Contains("t's an awful lot of work for me to do myself though")
            )
        {
            hekks2.SetActive(true);
            hekks1.SetActive(false);
        }
        else
        {
            hekks1.SetActive(true);
            hekks2.SetActive(false);
        }



        //this is the section of swaps for all the arrows showing up:

        if (lineInput.Contains("you can find me in the top right corner"))
        {
            arrow1.SetActive(true);
        }
        else
        {
            arrow1.SetActive(false);
        }


        if (lineInput.Contains("exit to the menu with the red button"))
        {
            arrow2.SetActive(true);
            arrow3.SetActive(true);
            resetButton.SetActive(true);
            exitButton.SetActive(true);
        }
        else
        {

            arrow2.SetActive(false);
            arrow3.SetActive(false);
            resetButton.SetActive(false);
            exitButton.SetActive(false);
        }

        if (lineInput.Contains("you can see the current recipe we will"))
        {
            arrow4.SetActive(true);
        }
        else
        {
            arrow4.SetActive(false);
        }

        if (lineInput.Contains("smack that big green button to start testing"))
        {
            arrow5.SetActive(true);
        }
        else
        {
            arrow5.SetActive(false);
        }

        if (lineInput.Contains("giant unending grey void is where"))
        { 
            arrow6.SetActive(true);
        }
        else
        {
            arrow6.SetActive(false);
        }

        if (lineInput.Contains("These will fill up the flask"))
        { 
            arrow7.SetActive(true);
            arrow8.SetActive(true);
        }
        else
        {
            arrow7.SetActive(false);
            arrow8.SetActive(false);
        }

        if (lineInput.Contains("red trash can icon"))
        {
            arrow9.SetActive(true);
        }
        else
        {
            arrow9.SetActive(false);
        }

        if (lineInput.Contains("drag it back into that grey void"))
        {
            arrow10.SetActive(true);
        }
        else
        {
            arrow10.SetActive(false);
        }

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