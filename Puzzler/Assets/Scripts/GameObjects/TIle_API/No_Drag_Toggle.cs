using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class No_Drag_ : MonoBehaviour
{
    private Draggable drag;
    private SpriteRenderer locked;

    // Start is called before the first frame update
    void Awake()
    {
        drag = GetComponent<Draggable>();
        locked = GetComponent<SpriteRenderer>();

        if (!drag.playerMovable)
        {
            locked.enabled = true;
        }
        else
        {
            locked.enabled = false;
        }
    }
}
