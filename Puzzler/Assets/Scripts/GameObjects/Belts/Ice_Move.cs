using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Move : Tile_Movement_Parent, Tile_Interface
{
    void Start()
    {
        thingsMoving = new List<Transform>();
        thingsMovingInitialPosition = new List<Vector3>();

        spotfound = false;
    }

    public void TurnMove()
    {
        StartCoroutine(moveThing("ice"));
    }

    public void TurnEffect() //Belts have no effect
    {
        
    }
}
