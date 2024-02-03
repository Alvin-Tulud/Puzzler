using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_TurnCheck : MonoBehaviour
{
    GameObject collidedObj;

    public void DoTurn()
    {
        //Debug.Log("ball will do its part");
        if(collidedObj != null)
        {
            var tileBelow = collidedObj.GetComponent<Tile_Interface>();

            tileBelow.TurnEffect(); //Triggers tile effect

            tileBelow.TurnMove(); //Triggers tile move
        }
        else //Should only trigger when the ball lands on the floor?
        {

        }
        collidedObj = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Debug.Log("hit");
            //Destroy both balls on collision
            Destroy(collision.GetComponentInParent<Transform>().gameObject);
            Destroy(gameObject.GetComponentInParent<Transform>().gameObject);
            //call build phase after
        }
        else if (collision.gameObject.layer == 6) //6 is belt layer
        {
            collidedObj = collision.gameObject;
        }

        else //Edge case for if the ball collides with something other than a tile, might be extra tho
        {
            //Debug.Log("LOSER"); //Presumably this only triggers when balls bump into each other meaning you LOSE!
        }
    }
}
