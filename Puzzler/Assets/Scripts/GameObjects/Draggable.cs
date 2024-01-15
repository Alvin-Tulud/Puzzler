using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Draggable : MonoBehaviour 
{
    private bool canMove;
    private bool dragging;
    private Collider2D collider;
    void Start()
    {
        collider = GetComponent<Collider2D>();
        canMove = false;
        dragging = false;
    }

    void OnMouseOver()
    {
        print(gameObject.name);
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (collider == Physics2D.OverlapPoint(mousePos))
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
}
