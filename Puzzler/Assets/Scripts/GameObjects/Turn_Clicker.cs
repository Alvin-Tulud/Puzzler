using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_Clicker : MonoBehaviour
{

    public int turnCounter; //Counts the number of elapsed turns, updates to this tell the factory to move

    // Start is called before the first frame update
    void Start()
    {
        turnCounter = 0;
        Debug.Log("Turn counter initialized and set  to 0 STUPID FREAKING KEYBOARD");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p"))
        {
            Debug.Log("P pressed");
            Increment();
        }
        
    }

    //ADD A FIXED UPDATE

    public void Increment()
    {
        turnCounter++; //increment the counter
        //notify observers of the change
        Debug.Log("INCREMENTING, counter is now " + turnCounter);
    }
}
