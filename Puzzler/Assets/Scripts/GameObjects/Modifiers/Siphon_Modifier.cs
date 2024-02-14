using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siphon_Modifier : Tile_Movement_Parent, Tile_Interface
{
    void Start()
    {
        transformBelt = transform;
        thingsMoving = new List<Transform>();
        thingsMovingInitialPosition = new List<Vector3>();
        times = new List<float>();

        spotfound = false;
    }

    public IEnumerator siphonLiquid()
    {//for each ball check if theres a liquid in it then check if there is take out the first layer that it finds
        foreach(Transform t in thingsMoving)
        {
            for (int i = 3; i >= 0; i--)
            {
                if (t.GetComponent<Ball_Modify>().getColorModList()[i].Length != 0)
                {
                    t.GetComponent<Ball_Modify>().setColorMod(i, "");
                    break;
                }
            }
        }
        yield return null;
    }

    public void TurnEffect()
    {
        StartCoroutine(siphonLiquid());
    }

    public void TurnMove()
    {
        StartCoroutine(moveThing());
    }
}
