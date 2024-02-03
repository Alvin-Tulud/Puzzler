using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Button : MonoBehaviour
{
    private RectTransform transform;
    public GameObject parent;
    public Animator animation;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<RectTransform>();
        i = 0;
    }

    public void next()
    {
        i++;
        if (i == 1)
        {
            animation.SetBool("Drag->Rotate", true);
        }
        else if (i == 2)
        {
            animation.SetBool("Drag->Rotate", false);
            animation.SetBool("Rotate->Flask", true);
        }
        else
        {
            animation.SetBool("Rotate->Flask", false);
            Destroy(parent);
        }
    }
}
