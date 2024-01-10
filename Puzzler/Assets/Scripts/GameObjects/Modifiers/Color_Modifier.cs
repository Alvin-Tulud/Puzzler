using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Modifier : Tile_Movement_Parent , Tile_Interface
{
    void Start()
    {
        transformBelt = this.gameObject.GetComponent<Transform>();

        thingsMoving = new List<Transform>();
        thingsMovingInitialPosition = new List<Vector3>();

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
            t.GetComponent<Ball_Modify>().addColorMod(color);
        }
        yield return null;//take each transform and turn it red
    }

    public void TurnMove()
    {
        Debug.Log("Red_Modifier moves ball");
        StartCoroutine(moveThing());
    }

    public void TurnEffect() //Belts have no effect
    {
        StartCoroutine(turnColor());
    }
}
