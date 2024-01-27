using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    private GameObject[] goals;
    public GameObject[] screen;

    private bool ready_to_check;
    private bool player_win;
    
    void Start()
    {
        goals = GameObject.FindGameObjectsWithTag("Goal");

        foreach(GameObject g in screen)
        {
            g.SetActive(false);
        }

        ready_to_check = false;
        player_win = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject go in goals)//when theres the right number of balls
        {
            if (!go.GetComponent<Goal_End>().correctNumberOfBalls())
            {
                ready_to_check = false;
                break;
            }
            else
            {
                ready_to_check = true;
            }
        }

        if (ready_to_check)//if the playter got it right
        {
            foreach( GameObject go in goals)
            {
                if (!go.GetComponent<Goal_End>().winState())
                {
                    player_win = false;
                    break;
                }
                else
                {
                    player_win = true;
                }
            }
        }

        if (player_win)//win screen if they win
        {
            foreach(GameObject g in screen)
            {
                g.SetActive(true);
            }
        }
    }
}
