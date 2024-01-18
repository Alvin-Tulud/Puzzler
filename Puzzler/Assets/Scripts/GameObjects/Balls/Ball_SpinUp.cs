using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_SpinUp : MonoBehaviour
{
    private void Update()//junk code just makes sure the thing stays upright i hope it works
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
