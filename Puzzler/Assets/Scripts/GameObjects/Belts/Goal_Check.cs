using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Check : MonoBehaviour
{
    public List<string> Goal_Colors = new List<string>(4);

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
