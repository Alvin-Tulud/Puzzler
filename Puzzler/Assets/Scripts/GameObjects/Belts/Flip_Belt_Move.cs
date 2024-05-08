using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip_Belt_Move : Tile_Movement_Parent, Tile_Interface
{
    private bool correctPosition;
    // Start is called before the first frame update
    void Start()
    {
        transformBelt = gameObject.GetComponentInParent<Transform>();
        thingsMoving = new List<Transform>();
        thingsMovingInitialPosition = new List<Vector3>();
        times = new List<float>();

        spotfound = false;

        correctPosition = true;
    }
    public void TurnMove()
    {
        StartCoroutine(moveThing());
    }

    public void TurnEffect() //Belts have no effect
    {
        transformBelt.RotateAround(transform.position, Vector3.forward, 180);
        FactoryRunAudio.FlipSwitchTileSFX();

        //flip-flop correctPosition to be true or false every time the belt flips
        //correctPosition will be used to flip the belts back to their original position after test phase
        if (correctPosition == true)
        {
            correctPosition = false;
        }
        else //if correctPosition == false
        {
            correctPosition = true;
        }
    }

    public void RealignFlipBelt()
    {
        if(correctPosition == false)
        {
            transformBelt.RotateAround(transform.position, Vector3.forward, 180);
            correctPosition = true;
        }
    }
}
