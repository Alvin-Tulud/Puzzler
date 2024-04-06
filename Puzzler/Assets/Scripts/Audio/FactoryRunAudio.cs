using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


[CreateAssetMenu(fileName = "FactoryRunAudioSO", menuName = "Create FactoryRunAudioSO")]

public class FactoryRunAudio : ScriptableObject
{
    public static void FactoryStartupSFX()
    {
        RuntimeManager.PlayOneShot("event:/SFX/FactoryRun/FactoryStart");
    }

    public static void FactoryStopSFX()
    {
        RuntimeManager.PlayOneShot("event:/SFX/FactoryRun/FactoryStop");
    }

    public static void DepositModSFX()
    {
        RuntimeManager.PlayOneShot("event:/SFX/FactoryRun/DepositMod");
    }




}
