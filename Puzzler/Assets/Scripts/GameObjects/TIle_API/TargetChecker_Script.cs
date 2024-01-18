using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetChecker_Script : MonoBehaviour
{
    bool touchingFactoryTile;

    // Start is called before the first frame update
    void Start()
    {
        touchingFactoryTile = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("");

        //We may need to do something with layermasks regarding this
        if(collision.gameObject.layer == 6) //If the collision is a belt layer
        {
            touchingFactoryTile = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("");
        touchingFactoryTile = false;
    }
}
