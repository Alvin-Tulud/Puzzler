using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Belt_Move : MonoBehaviour
{
    private Transform   transformBelt;
    private float       directionBelt;

    private Transform   thingMoving;
    private Vector3     thingMovingInitialPosition;
    private Vector3     thingMovingCurrentPosition;
    public  int         speedBelt;
    private float       time;
    // Start is called before the first frame update
    void Start()
    {
        transformBelt = this.gameObject.GetComponent<Transform>();
        directionBelt = transform.rotation.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (thingMoving != null) // check if ball on belt
        {
            thingMoving.rotation = Quaternion.Euler(0f, 0f, directionBelt);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            thingMoving = collision.transform;
            thingMovingInitialPosition = collision.transform.position;
        }
    }
}
