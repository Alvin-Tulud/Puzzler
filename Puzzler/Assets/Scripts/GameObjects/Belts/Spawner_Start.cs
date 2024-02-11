using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Start : Tile_Movement_Parent, Tile_Interface
{
    public GameObject Flask_To_Spawn;
    public GameObject Flask_To_Show;
    private bool isSpawned;

    void Start()
    {
        thingsMoving = new List<Transform>();
        thingsMovingInitialPosition = new List<Vector3>();

        spotfound = false;

        isSpawned = false;
    }

    public void TurnMove()
    {
        StartCoroutine(moveThing());
    }
    public void TurnEffect()
    {
        if (!isSpawned)
        {
            Instantiate(Flask_To_Spawn,transform.position,transform.rotation);
            isSpawned = true;
        }
    }

    public void setIsSpawned(bool state) { isSpawned = state; }

    public void showFlask(bool show) { Flask_To_Show.SetActive(show); }

}
