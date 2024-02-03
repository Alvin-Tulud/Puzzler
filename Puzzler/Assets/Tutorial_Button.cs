using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Button : MonoBehaviour
{
    private RectTransform transform;
    public GameObject parent;
    public Animator animation;
    public AnimationClip[] clips;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<RectTransform>();
        foreach(AnimationClip clip in clips)
        {
            
        }
        i = 0;
    }

    public void next()
    {
        i++;
        if (i < clips.Length)
        {

        }
        else
        {
            Destroy(parent);
        }
    }
}
