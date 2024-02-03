using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Button : MonoBehaviour
{
    private RectTransform transform;
    public GameObject parent;
    public Animator animation;
    private int i;
    private int previousrand;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<RectTransform>();
        i = 0;
    }

    public void next()
    {
        int rand = Random.Range(100, 1100);
        while (Mathf.Abs(rand - previousrand) < 250)
        {
            rand = Random.Range(100, 1100);
        }

        i++;
        if (i == 1)
        {
            animation.SetBool("Drag->Rotate", true);

            transform.position = new Vector3(rand, transform.position.y, transform.position.z);
            previousrand = rand;
        }
        else if (i == 2)
        {
            animation.SetBool("Drag->Rotate", false);
            animation.SetBool("Rotate->Flask", true);

            transform.position = new Vector3(rand, transform.position.y, transform.position.z);
        }
        else
        {
            animation.SetBool("Rotate->Flask", false);
            Destroy(parent);
        }
    }
}
