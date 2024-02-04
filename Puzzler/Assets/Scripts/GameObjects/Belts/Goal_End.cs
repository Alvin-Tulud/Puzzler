using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_End : MonoBehaviour, Tile_Interface
{
    public List<string> Goal_Colors = new List<string>(4);
    private bool isRight;
    private List<bool> checkBalls = new List<bool>();
    public int number_of_balls;
    private int balls_found = 0;
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
            collision.GetComponent<CircleCollider2D>().enabled = false;

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
                checkBalls.Add(true);
            }
            else
            {
                checkBalls.Add(false);
            }
            balls_found++;
        }
    }

    public List<string> getGoalColors() { return Goal_Colors; }

    public bool winState()
    {
        if (checkBalls.Count != 0)
        {
            foreach (bool b in checkBalls)
            {
                if (!b)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool correctNumberOfBalls()
    {
        if (balls_found == number_of_balls)
        {
            return true;
        }
        return false;
    }

    public void ballsReset()
    {
        balls_found = 0;
        checkBalls.Clear();
    }
}
