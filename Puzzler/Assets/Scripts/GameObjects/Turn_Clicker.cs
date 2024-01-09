using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_Clicker : MonoBehaviour
{

    public int turnCounter; //Counts the number of elapsed turns, updates to this tell the factory to move
    public GameObject[] balls;

    // Start is called before the first frame update
    void Start()
    {
        turnCounter = 0;
        //Debug.Log("Turn counter initialized and set  to 0 STUPID FREAKING KEYBOARD");
        balls = GameObject.FindGameObjectsWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p"))
        {
            //Debug.Log("P pressed");
            DoTurn();
        }
        
    }

    //ADD A FIXED UPDATE

    public void DoTurn() //Run the next turn
    {
        turnCounter++; //increment the counter
        //notify observers of the change
        Debug.Log("INCREMENTING, counter is now " + turnCounter);

        

        foreach(GameObject ball in balls)
        {
            ball.GetComponent<Ball_TurnBased>().DoTurn(); //ALL BALLS will do their turn
        }

    }
}
