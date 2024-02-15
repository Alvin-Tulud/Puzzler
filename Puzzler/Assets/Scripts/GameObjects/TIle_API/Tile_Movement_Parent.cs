using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Movement_Parent : MonoBehaviour
{
    protected Transform transformBelt;

    protected private List<Transform> thingsMoving;
    protected private List<Vector3> thingsMovingInitialPosition;
    protected private Vector3 thingMovingCurrentPosition;
    protected private int speedBelt = 10;
    protected private List<float> times;
    protected private bool spotfound;
    protected private bool canMove;

    private void FixedUpdate()
    {
        if (canMove)
        {
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;//turn off so it doesn't detect other balls while its running
            try
            {
                for (int i = 0; i < thingsMoving.Count; i++)
                {
                    Transform t = thingsMoving[i];
                    if (t != null && times[i] <= speedBelt) //check if ball is stored and if the timer on it isn't maxxed
                    {
                        Vector3 right = new Vector3(Mathf.Round(t.right.x), Mathf.Round(t.right.y), 0);
                        thingMovingCurrentPosition = Vector3.Lerp(transformBelt.position, right + transformBelt.position, times[i] / speedBelt);

                        thingsMoving[i].position = new Vector3(thingMovingCurrentPosition.x, thingMovingCurrentPosition.y, 0f);
                        times[i]++;
                    }
                    else
                    {
                        thingsMoving[i] = null;
                        thingsMovingInitialPosition[i] = Vector3.zero;
                        times[i] = 0;
                        canMove = false;
                        this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
                    }
                }
            }
            catch (System.Exception e)
            {
                //balls
            }
        }
    }

    public IEnumerator moveThing(string type = "belt")
    {
        canMove = true;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision) // detect ball on belt //do something so it doesnt fuck up with multiple balls on same belt
    {
        if (collision.CompareTag("Ball"))
        {
            if (transformBelt.CompareTag("Flip_Belt"))
            {
                collision.transform.rotation = Quaternion.Inverse(transformBelt.rotation);
            }
            else if (!transformBelt.CompareTag("Ice"))
            {
                collision.transform.rotation = transformBelt.rotation; //rotate ball to be same facing as the belt
            }
            
            for (int i = 0; i < thingsMoving.Count; i++)
            {
                Transform t = thingsMoving[i];
                if (t == null)//if found empty spot change bool to yes and set it to that spot and reset the timer attached at same index and get the initial position of it
                {
                    thingsMoving[i] = collision.transform;
                    thingsMovingInitialPosition[i] = collision.transform.position;
                    times[i] = 0;
                    spotfound = true;
                    break;//breaks when it finds a free space
                }
            }

            if (!spotfound)//if no spot add it to the end and add another time var  
            {
                thingsMoving.Add(collision.transform);
                thingsMovingInitialPosition.Add(collision.transform.position);
                times.Add(0);
            }

            spotfound = false; //reset to default
        }
    }
}
