using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Movement_Parent : MonoBehaviour
{
    protected Transform transformBelt;

    protected List<Transform> thingsMoving;
    protected List<Vector3> thingsMovingInitialPosition;
    protected Vector3 thingMovingCurrentPosition;
    public int speedBelt = 5;
    protected float time;
    protected bool spotfound;

    public IEnumerator moveThing(string type = "belt")
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;//turn off so it doesn't detect other balls while its running

        time = 0f;

        while (time <= speedBelt)
        {
            for (int i = 0; i < thingsMoving.Count; i++)
            {
                Transform t = thingsMoving[i];

                if(!type.Equals("ice")) //if ice block, DONT reorient the ball so it keeps going in the same direction
                {
                    t.transform.rotation = transformBelt.rotation; //rotate ball to be same facing as the belt
                }


                if (t != null) //check if ball is stored and if the timer on it isn't maxxed
                {
                    thingMovingCurrentPosition.x = Mathf.Lerp(thingsMovingInitialPosition[i].x, transformBelt.right.x + transformBelt.position.x, time / speedBelt);
                    thingMovingCurrentPosition.y = Mathf.Lerp(thingsMovingInitialPosition[i].y, transformBelt.right.y + transformBelt.position.y, time / speedBelt);

                    thingsMoving[i].position = new Vector3(thingMovingCurrentPosition.x, thingMovingCurrentPosition.y, 0f);
                }
            }
            time += Time.fixedDeltaTime;

            yield return null;
        }

        thingsMoving.Clear();

        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision) // detect ball on belt //do something so it doesnt fuck up with multiple balls on same belt
    {
        if (collision.CompareTag("Ball"))
        {
            for (int i = 0; i < thingsMoving.Count; i++)
            {
                Transform t = thingsMoving[i];
                if (t == null)//if found empty spot change bool to yes and set it to that spot and reset the timer attached at same index and get the initial position of it
                {
                    thingsMoving[i] = collision.transform;
                    thingsMovingInitialPosition[i] = collision.transform.position;
                    spotfound = true;
                    break;//breaks when it finds a free space
                }
            }

            if (!spotfound)//if no spot add it to the end and add another time var  
            {
                thingsMoving.Add(collision.transform);
                thingsMovingInitialPosition.Add(collision.transform.position);
            }

            spotfound = false; //reset to default
        }
    }
}
