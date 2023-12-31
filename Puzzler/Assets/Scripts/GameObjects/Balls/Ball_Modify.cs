using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Modify : MonoBehaviour
{
    List<string> modifications; 
    // Start is called before the first frame update
    void Start()
    {
        modifications = new List<string>();
        modifications.Add("");//color i0
        modifications.Add("");//temperature i1
        modifications.Add("");//idk i2 etc. etc. etc.
    }

    public void setMod(int index, string mod)//changes modification on set index
    {
        modifications[index] = mod;
    }

    public List<string> getMod() { return modifications; }//returns lists to check for win condition
}
