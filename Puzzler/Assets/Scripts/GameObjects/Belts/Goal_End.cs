using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_End : MonoBehaviour, Tile_Interface
{
    public List<string> Goal_Colors = new List<string>(4);
    private bool isRight;

    public void TurnMove()
    {
        
    }

    public void TurnEffect() //Belts have no effect
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            isRight = true;
            for (int i = 0; i < Goal_Colors.Count; i++)
            {
                if (collision.GetComponent<Ball_Modify>().getColorModList()[i] != Goal_Colors[i])
                {
                    isRight = false;
                    break;
                }
            }
            if (isRight)
            {
                Debug.Log("a match");
            }
            else
            {
                Debug.Log("not a match");
            }
        }
    }

    public List<string> getGoalColors() { return Goal_Colors; }
}