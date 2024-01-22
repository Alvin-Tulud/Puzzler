using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip_Belt_Move : Tile_Movement_Parent, Tile_Interface
{
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
        StartCoroutine(moveThing());
    }

    public void TurnEffect() //Belts have no effect
    {
        transformBelt.RotateAround(transform.position, Vector3.forward, 180);
    }
}
