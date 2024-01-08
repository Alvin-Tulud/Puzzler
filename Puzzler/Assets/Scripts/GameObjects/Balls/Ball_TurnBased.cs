using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_TurnBased : MonoBehaviour
{

    GameObject collidedObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoTurn()
    {
        //Debug.Log("ball will do its part");
        if(collidedObj != null)
        {
            collidedObj.GetComponent<Tile_Interface>().TurnEffect(); //Triggers tile effect

            collidedObj.GetComponent<Tile_Interface>().TurnMove(); //Triggers tile move
        }
        else //Should only trigger when the ball lands on the floor?
        {

        }
        collidedObj = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) //6 is belt layer
        {
            collidedObj = collision.gameObject;
        }

        else //Edge case for if the ball collides with something other than a tile, might be extra tho
        {
            Debug.Log("LOSER"); //Presumably this only triggers when balls bump into each other meaning you LOSE!
        }
    }
}
