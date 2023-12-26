using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Belt_Move : MonoBehaviour
{
    private Transform   transformBelt;

    private Transform   thingMoving;
    private Vector3     thingMovingInitialPosition;
    private Vector3     thingMovingCurrentPosition;
    public  int         speedBelt;
    private float       time;

    void Start()
    {
        transformBelt = this.gameObject.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (thingMoving != null) // check if ball stored
        {
            if (time <= speedBelt)
            {
                thingMovingCurrentPosition.x = Mathf.Lerp(thingMovingInitialPosition.x, transformBelt.right.x + transformBelt.position.x, time / speedBelt);
                thingMovingCurrentPosition.y = Mathf.Lerp(thingMovingInitialPosition.y, transformBelt.right.y + transformBelt.position.y, time / speedBelt);

                thingMoving.position = new Vector3(thingMovingCurrentPosition.x, thingMovingCurrentPosition.y, 0f);

                time++;
            }
            else //stop moving ball
            {
                thingMoving = null;
                time = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // detect ball on belt //do something so it doesnt fuck up with multiple balls on same belt
    {
        if (collision.CompareTag("Ball"))
        {
            thingMoving = collision.transform;
            thingMovingInitialPosition = collision.transform.position;
        }
    }
}
