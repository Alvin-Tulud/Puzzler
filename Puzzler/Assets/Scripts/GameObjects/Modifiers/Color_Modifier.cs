using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Modifier : Tile_Movement_Parent , Tile_Interface
{
    void Start()
    {
        transformBelt = gameObject.GetComponentInParent<Transform>();
        thingsMoving = new List<Transform>();
        thingsMovingInitialPosition = new List<Vector3>();
        times = new List<float>();

        spotfound = false;
    }

    public IEnumerator turnColor()
    {
        string color;

        switch (this.gameObject.tag)
        {
            case "Red_Modifier":
                color = "red";
                break;
            case "Yellow_Modifier":
                color = "yellow";
                break;
            case "Blue_Modifier":
                color = "blue";
                break;
            default:
                color = "";
                break;
        }
        
        foreach(Transform t in thingsMoving)
        {
            for (int i = 0; i < 4 ; i++)
            {
                if (t.GetComponent<Ball_Modify>().getColorModList()[i].Length == 0)
                {
                    t.GetComponent<Ball_Modify>().setColorMod(i, color);
                    break;
                }
            }
        }
        yield return null;//take each transform and turn it red
    }

    public void TurnMove()
    {
        StartCoroutine(moveThing());
    }

    public void TurnEffect() //Belts have no effect
    {
        StartCoroutine(turnColor());
    }
}
