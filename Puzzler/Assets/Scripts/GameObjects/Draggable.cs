using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool isDraggable;
    private bool isMoving;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("start drag");
        isMoving = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("drag");
        if (isDraggable)
        {
            transform.position = new Vector3(Mathf.Round(Input.mousePosition.x), Mathf.Round(Input.mousePosition.y), 0);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
        isMoving = false;
    }

    private void Update()
    {
        if (isMoving && Input.GetKeyDown("r"))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - 90);
        }
    }
}
