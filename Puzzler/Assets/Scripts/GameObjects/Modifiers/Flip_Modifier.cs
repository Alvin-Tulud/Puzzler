using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip_Modifier : Tile_Movement_Parent, Tile_Interface
{
    void Start()
    {
        transformBelt = gameObject.GetComponentInParent<Transform>();
        thingsMoving = new List<Transform>();
        thingsMovingInitialPosition = new List<Vector3>();
        times = new List<float>();

        spotfound = false;
    }

    public IEnumerator flipLiquid()
    {//flip the array but also keep it in the same place
        foreach(Transform t in thingsMoving)
        {
            FactoryRunAudio.FlipSwitchTileSFX();
            List<string> tempColorsList = t.GetComponent<Ball_Modify>().getColorModList();
            tempColorsList.Reverse();
            for (int i = 0; i < tempColorsList.Count - 1; i++)
            {
                if (tempColorsList[i].Length > 0)
                {
                    break;
                }
                else
                {
                    for (int j = i + 1; j < tempColorsList.Count; j++)
                    {
                        if (tempColorsList[i].Length > 0 && tempColorsList[j].Length > 0)
                        {
                            break;
                        }
                        else
                        {
                            string tempColor = tempColorsList[i];
                            tempColorsList[i] = tempColorsList[j];
                            tempColorsList[j] = tempColor;
                        }
                    }
                }
            }
            t.GetComponent<Ball_Modify>().setColorModList(tempColorsList);
        }
        yield return null;
    }

    public void TurnEffect()
    {
        StartCoroutine(flipLiquid());
    }

    public void TurnMove()
    {
        StartCoroutine(moveThing());
    }
}