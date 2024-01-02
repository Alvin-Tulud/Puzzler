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
    }

    public void addMod(string mod)
    {
        if (modifications.Count < 4)
        {
            modifications.Add(mod);
        }
    }

    public void setMod(int index, string mod)//changes modification on set index
    {
        modifications[index] = mod;
    }

    public void setModList(List<string> modifications)
    {
        this.modifications = modifications;
    }

    public List<string> getMod() { return modifications; }//returns lists to check for win condition
}
