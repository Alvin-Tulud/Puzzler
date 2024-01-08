using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt_Move_TurnBased : Tile_Movement_Parent, Tile_Interface
{
    //private Transform transformBelt;

    // Start is called before the first frame update
    void Start()
    {
        transformBelt = this.gameObject.GetComponent<Transform>();

        thingsMoving = new List<Transform>();
        thingsMovingInitialPosition = new List<Vector3>();

        spotfound = false;
    }

    public void TurnMove()
    {
        Debug.Log("Belt moves ball");
        StartCoroutine(moveThing("ice"));
    }

    public void TurnEffect() //Belts have no effect
    {
        Debug.Log("Belt effect (none)");
    }

}
