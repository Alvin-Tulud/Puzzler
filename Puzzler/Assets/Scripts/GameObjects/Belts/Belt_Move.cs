using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt_Move : Tile_Movement_Parent, Tile_Interface
{
    void Start()
    {
        transformBelt = this.gameObject.GetComponent<Transform>();

        thingsMoving = new List<Transform>();
        thingsMovingInitialPosition = new List<Vector3>();

        spotfound = false;
    }

    public void TurnMove()
    {
        StartCoroutine(moveThing());
    }

    public void TurnEffect() //Belts have no effect
    {
        
    }

}
