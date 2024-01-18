using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Draggable : MonoBehaviour 
{
    public bool playerMovable;
    private bool canMove;
    private bool dragging;
    private Collider2D collider;
    public GameObject DragTarget;
    public GameObject TargetChecker;
    private bool touchingFactoryTile;
    //private bool collidingWithFloor;   //NOT sure if we even want colliders with the floor, placeholder for when we implement floor tiles
    void Start()
    {
        collider = GetComponent<Collider2D>();
        canMove = false;
        dragging = false;
    }

    private void Update()// code taken from here https://generalistprogrammer.com/game-design-development/unity-drag-and-drop-tutorial/
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//doesn't work for some reason when i try to simplify it
        if (Input.GetMouseButtonDown(0)) //on click down
        {
            if (playerMovable && collider == Physics2D.OverlapPoint(mousePos))//figure out how to make it so the tiles cant be placed on eachother
            {
                canMove = true;
                Instantiate(DragTarget, transform.position, transform.rotation); //Creates DragTarget
                Instantiate(TargetChecker, transform.position, transform.rotation); //Creates TargetChecker

                //need to initialize collision logic for targetchecker here
            }
            else
            {
                canMove = false;
            }
            if (canMove)
            {
                dragging = true;
            }
        }
        if (dragging) //while dragging
        {
            //create DragTarget object - visual representation of landing position
            //create TargetChecker object - hidden validity checker for DragTarget
            //Check if rounded position is safe: 
            //1. Round TargetChecker's position: TargetChecker.transform.position = new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0);
            //2. Check if TargetChecker's position is valid:
            //2a: MUST be above a floor space (TBA)
            //2b: Must NOT be colliding with a belt
            //3. If the above are true, Set DragTarget's position to TargetChecker's
            //this.transform.position = new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0);
            
            this.transform.position = new Vector3(mousePos.x, mousePos.y, 0); //moves tile to mouse pos

            TargetChecker.transform.position = new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0); //Moves TargetChecker and rounds its pos to the tile grid
            //Debug.Log(TargetChecker.transform.position); Apparently it's moving even though it looks like it isn't?

            //move target to checker's position if it's valid
            TargetChecker_Script checkerScript = TargetChecker.GetComponent<TargetChecker_Script>();
            touchingFactoryTile = checkerScript.BoolCheck(); //determines true/false based on the targetChecker's script

            if(touchingFactoryTile == true)
            {
                DragTarget.transform.position = TargetChecker.transform.position;
            }



            if (Input.GetKeyDown("r"))
            {
                transform.Rotate(0, 0, -90);
            }
        }
        if (Input.GetMouseButtonUp(0)) //when letting go
        {
            canMove = false;
            dragging = false;
            //place the dragged tile at target location
            //destroy target and targetChecker

            this.transform.position = DragTarget.transform.position;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.IsTouchingLayers(6))
        {
            Debug.Log("ontop");
        }
    }
}
