using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Move : Tile_Movement_Parent, Tile_Interface
{
    void Start()
    {
        transformBelt = this.gameObject.GetComponent<Transform>(); //I renamed transformIce to transformBelt since it has to for the parent script sorry

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
