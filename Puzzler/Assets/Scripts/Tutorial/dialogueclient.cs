using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueclient : MonoBehaviour
{

    public TextAsset tutorialInk;

    private GameObject textManager;

    //private bool storyEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        textManager = GameObject.Find("dialogueManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Debug.Log("START STORY");
            //storyEnd = true;
            //Debug.Log("LOCKED STORY");
            textManager.GetComponent<DialogueTutorial>().enterDialogue(tutorialInk);
            //storyEnd = false;
            //Debug.Log("END STORY");
        }
    }
}
