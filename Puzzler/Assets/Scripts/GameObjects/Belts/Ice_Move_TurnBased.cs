using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Move_TurnBased : Tile_Movement_Parent, Tile_Interface
{
    //private Transform transformIce;

    //private List<Transform> thingsMoving;
    //private List<Vector3> thingsMovingInitialPosition;
    //private Vector3 thingMovingCurrentPosition;
    //public int speedIce;
    //private float time;
    //private bool spotfound;


    // Start is called before the first frame update
    void Start()
    {
        transformBelt = this.gameObject.GetComponent<Transform>(); //I renamed transformIce to transformBelt since it has to for the parent script sorry

        thingsMoving = new List<Transform>();
        thingsMovingInitialPosition = new List<Vector3>();

        spotfound = false;
    }

    //public IEnumerator moveThing()
    //{
    //    this.gameObject.GetComponent<BoxCollider2D>().enabled = false;//turn off so it doesn't detect other balls while its running
    //
    //    time = 0f;
    //
    //    while (time <= speedIce)
    //    {
    //        for (int i = 0; i < thingsMoving.Count; i++)
    //        {
    //            Transform t = thingsMoving[i];
    //            if (t != null) //check if ball is stored and if the timer on it isn't maxxed
    //            {
    //                thingMovingCurrentPosition.x = Mathf.Lerp(thingsMovingInitialPosition[i].x, t.right.x + transformIce.position.x, time / speedIce);
    //                thingMovingCurrentPosition.y = Mathf.Lerp(thingsMovingInitialPosition[i].y, t.right.y + transformIce.position.y, time / speedIce);
    //
    //                thingsMoving[i].position = new Vector3(thingMovingCurrentPosition.x, thingMovingCurrentPosition.y, 0f);
    //            }
    //        }
    //        time += Time.fixedDeltaTime;
    //
    //        yield return null;
    //    }
    //
    //    thingsMoving.Clear();
    //
    //    this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    //
    //    yield return null;
    //}

    public void TurnMove()
    {
        Debug.Log("Ice moves ball");
        StartCoroutine(moveThing("ice"));
    }

    public void TurnEffect() //Belts have no effect
    {
        Debug.Log("Ice effect (none)");
    }

    //private void OnTriggerEnter2D(Collider2D collision) // detect ball on belt //do something so it doesnt fuck up with multiple balls on same belt
    //{
    //    if (collision.CompareTag("Ball"))
    //    {
    //        for (int i = 0; i < thingsMoving.Count; i++)
    //        {
    //            Transform t = thingsMoving[i];
    //            if (t == null)//if found empty spot change bool to yes and set it to that spot and reset the timer attached at same index and get the initial position of it
    //            {
    //                thingsMoving[i] = collision.transform;
    //                thingsMovingInitialPosition[i] = collision.transform.position;
    //                spotfound = true;
    //                break;//breaks when it finds a free space
    //            }
    //        }
    //
    //        if (!spotfound)//if no spot add it to the end and add another time var  
    //        {
    //            thingsMoving.Add(collision.transform);
    //            thingsMovingInitialPosition.Add(collision.transform.position);
    //        }
    //
    //        spotfound = false; //reset to default
    //    }
    //}
}
