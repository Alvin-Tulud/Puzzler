using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_Phase_Initialize : MonoBehaviour
{
    private bool buildStart;
    private GameObject[] draggable;
    // Start is called before the first frame update
    void Start()
    {
        //grab all of the draggables scripts and enable them then disable them when buildStart is false
        //turn on at the start of the level have some other thing to handle the button clicks on the ui to start and stop stuff
        draggable = GameObject.FindGameObjectsWithTag("Draggable");
    }

    // Update is called once per frame
    void Update()
    {
        if (!buildStart)
        {
            foreach(GameObject g in draggable)
            {
                g.GetComponent<Draggable>().state(false);
            }
        }
        else if (buildStart)
        {
            foreach(GameObject g in draggable)
            {
                g.GetComponent<Draggable>().state(true);
            }
        }
    }

    public void state(bool state) { buildStart = state; }
}
