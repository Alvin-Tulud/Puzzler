using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Modify : MonoBehaviour
{
    public List<string> Color_Modifications = new List<string>(4);
    public bool hot;
    public bool cold;

    void Start()
    {
        for (int i = 0; i < Color_Modifications.Count; i++)
        {
            Color_Modifications[i] = "";
        }

        hot = false;
        cold = false;
    }

    //-------------- Color things-------------------------------------------
    public void setColorMod(int index, string mod)//changes modification on set index
    {
        Color_Modifications[index] = mod;
    }

    public void setColorModList(List<string> Color_Modifications)//for when colors mix
    {
        this.Color_Modifications = Color_Modifications;
    }

    public List<string> getColorModList() { return Color_Modifications; }//returns lists to check for win condition

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
