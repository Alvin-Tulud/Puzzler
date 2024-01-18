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
    void Start()
    {
        collider = GetComponent<Collider2D>();
        canMove = false;
        dragging = false;
    }

    private void Update()// code taken from here https://generalistprogrammer.com/game-design-development/unity-drag-and-drop-tutorial/
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//doesn't work for some reason when i try to simplify it
        if (Input.GetMouseButtonDown(0))
        {
            if (playerMovable && collider == Physics2D.OverlapPoint(mousePos))//figure out how to make it so the tiles cant be placed on eachother
            {
                canMove = true;
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
        if (dragging)
        {
            this.transform.position = new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0);

            if (Input.GetKeyDown("r"))
            {
                transform.Rotate(0, 0, -90);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            dragging = false;
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
