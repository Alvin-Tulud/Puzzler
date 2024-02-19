using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShaping : MonoBehaviour
{
    void Awake()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.01f;
    }
}
