using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class No_Drag_ : MonoBehaviour
{
    private Draggable drag;
    private Image locked;

    // Start is called before the first frame update
    void Start()
    {
        drag = GetComponent<Draggable>();

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
