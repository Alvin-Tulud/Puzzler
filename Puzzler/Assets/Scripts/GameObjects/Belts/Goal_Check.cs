using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Check : MonoBehaviour, Tile_Interface
{
    public List<string> Goal_Colors = new List<string>(4);

    public void TurnMove()
    {
        Debug.Log("do nothing");
    }

    public void TurnEffect() //Belts have no effect
    {
        Debug.Log("do nothing");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if (collision.GetComponent<Ball_Modify>().getColorMod().Equals(Goal_Colors))
            {
                Debug.Log("you suck");
            }
            else
            {
                Debug.Log("a match");
            }
        }
    }

    public List<string> getGoalColors() { return Goal_Colors; }
}
