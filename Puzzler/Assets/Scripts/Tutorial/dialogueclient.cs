using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueclient : MonoBehaviour
{

    public TextAsset tutorialInk;

    private GameObject textManager;

    public bool storyStart = false;

    //private bool storyEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        textManager = GameObject.Find("dialogueManager");
        storyStart = true;
        textManager.GetComponent<DialogueTutorial>().enterDialogue(tutorialInk); //tells the other script to enter with the tutorial ink story file.
    }

    // Update is called once per frame
    void Update()
    {
        //if (storyStart == false)
        {
            //if (Input.GetKeyDown(KeyCode.Q)) //when pressing q, story will start
            {
                //storyStart = true;
                //textManager.GetComponent<DialogueTutorial>().enterDialogue(tutorialInk); //tells the other script to enter with the tutorial ink story file.
            }
        }
    }


    public void storySetter()
    {
        storyStart = false;
    }
}
