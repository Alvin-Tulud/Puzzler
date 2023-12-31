using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Move : MonoBehaviour
{
    private Transform transformIce;

    private List<Transform> thingsMoving;
    private List<Vector3> thingsMovingInitialPosition;
    private Vector3 thingMovingCurrentPosition;
    public int speedBelt;
    private List<float> times;
    private bool spotfound;
    // Start is called before the first frame update
    void Start()
    {
        transformIce = this.gameObject.GetComponent<Transform>();

        thingsMoving = new List<Transform>();
        thingsMovingInitialPosition = new List<Vector3>();
        times = new List<float>();

        spotfound = false;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < thingsMoving.Count; i++)
        {
            Transform t = thingsMoving[i];
            if (t != null && times[i] <= speedBelt) //check if ball is stored and if the timer on it isn't maxxed
            {
                thingMovingCurrentPosition.x = Mathf.Lerp(thingsMovingInitialPosition[i].x, t.right.x + transformIce.position.x, times[i] / speedBelt);// move it based on the rotation of the ball
                thingMovingCurrentPosition.y = Mathf.Lerp(thingsMovingInitialPosition[i].y, t.right.y + transformIce.position.y, times[i] / speedBelt);

                thingsMoving[i].position = new Vector3(thingMovingCurrentPosition.x, thingMovingCurrentPosition.y, 0f);

                times[i]++;
            }
            else
            {
                thingsMoving[i] = null;
                thingsMovingInitialPosition[i] = Vector3.zero;
                times[i] = 0;
            }
        }
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
