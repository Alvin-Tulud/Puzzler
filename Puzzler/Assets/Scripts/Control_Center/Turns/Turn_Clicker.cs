using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_Clicker : MonoBehaviour
{
    public int turnCounter; //Counts the number of elapsed turns, updates to this tell the factory to move
    public GameObject[] balls;

    private int timer;
    private int timerlimit;
    private bool stopping; //True when stopping test phase, false normally

    private void OnEnable()
    {
        turnCounter = 0;
        //Debug.Log("Turn counter initialized and set  to 0 STUPID FREAKING KEYBOARD");
        balls = GameObject.FindGameObjectsWithTag("Ball");
        timer = 0;
        timerlimit = 20;
        stopping = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown("p"))
        //{
        //    //Debug.Log("P pressed");
        //    DoTurn();
        //}
    }

    private void FixedUpdate()
    {
        timer++;
        if(timer >= timerlimit)
        {
            if(stopping)
            {
                Play_Button PlayButton = GameObject.FindWithTag("Play_Button").GetComponent<Play_Button>();
                PlayButton.StartBuildPhase();

                stopping = false;
            }
            else
            {
                DoTurn();
                timer = 0;
            }
        }
    }

    //ADD A FIXED UPDATE

    public void DoTurn() //Run the next turn
    {
        turnCounter++; //increment the counter
        //notify observers of the change
        //Debug.Log("INCREMENTING, counter is now " + turnCounter);
        try
        {
            foreach (GameObject ball in balls)
            {
                ball.GetComponent<Ball_TurnCheck>().DoTurn(); //ALL BALLS will do their turn
                //Debug.Log(ball.transform.name + "MOVED");
            }
        }
        catch(System.Exception e) { }
        
    }

    public void Stopping(bool stop)
    {
        stopping = stop;
    }
}

