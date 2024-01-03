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
        Debug.Log("ball will do its part");
        if(collidedObj != null)
        {
            //collidedObj.Invoke(""); interface
            collidedObj.GetComponent<Tile_Interface>().TurnPart1();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collidedObj = collision.gameObject;
        }

        else
        {
            Debug.Log("LOSER"); //Presumably this only triggers when balls bump into each other meaning you LOSE!
        }
    }
}
