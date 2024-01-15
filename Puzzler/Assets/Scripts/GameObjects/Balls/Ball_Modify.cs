using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Modify : MonoBehaviour
{
    public List<string> Color_Modifications;
    public bool hot;
    public bool cold;

    void Start()
    {
        Color_Modifications = new List<string>();
        hot = false;
        cold = false;
    }

    private void Update()//junk code just makes sure the thing stays upright i hope it works
    {
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    //-------------- Color things-------------------------------------------
    public void addColorMod(string mod)
    {
        if (Color_Modifications.Count < 4)
        {
            Color_Modifications.Add(mod);
        }
    }
    public void setColorMod(int index, string mod)//changes modification on set index
    {
        Color_Modifications[index] = mod;
    }

    public void setColorModList(List<string> Color_Modifications)//for when colors mix
    {
        this.Color_Modifications = Color_Modifications;
    }

    public List<string> getColorMod() { return Color_Modifications; }//returns lists to check for win condition

    //------------------temperature stuff-----------------------------------------

    public void isHot()//flip flop
    {
        hot = true;
        cold = false;
    }

    public void isCold()//flip flop
    {
        cold = true;
        hot = false;
    }
}
