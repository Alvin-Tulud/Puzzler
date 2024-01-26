using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tempurature : Tile_Movement_Parent, Tile_Interface
{
    void Start()
    {
        thingsMoving = new List<Transform>();
        thingsMovingInitialPosition = new List<Vector3>();

        spotfound = false;
    }

    public IEnumerator changeTemp()
    {
        foreach (Transform t in thingsMoving)
        {
            switch (this.gameObject.tag)
            {
                case "Heat_Modifier":
                    break;
                case "Cold_Modifier":
                    break;
                default:
                    break;
            }
        }
        yield return null;
    }

    public void TurnMove()
    {
        StartCoroutine(moveThing());
    }

    public void TurnEffect() //Belts have no effect
    {
        StartCoroutine(changeTemp());
    }

    public void heatColors(GameObject g, List<string> colors)
    {
        
    }

    public void chillColors(GameObject g, List<string> colors)
    {

    }
}
