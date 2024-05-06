using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Modify : MonoBehaviour
{
    public List<string> Color_Modifications = new List<string>(4);
    public bool hot;
    public bool cold;
    int filledMods = 0;

    void Start()
    {
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

    //-------------- SFX things-------------------------------------------

    public void playColorModSFX()
    {
        foreach(string s in Color_Modifications) //checks how many of the mod slots are filled
        {
            if (s != "")
            {
                filledMods++;
            }
        }
        FactoryRunAudio.DepositModSFX(filledMods);
        filledMods = 0;
    }


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
