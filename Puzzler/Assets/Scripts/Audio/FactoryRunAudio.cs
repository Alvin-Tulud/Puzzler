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

    public static void GoalSuccess()
    {
        RuntimeManager.PlayOneShot("event:/SFX/FactoryRun/GoalSuccess");
    }

    public static void GoalReject()
    {
        RuntimeManager.PlayOneShot("event:/SFX/FactoryRun/GoalReject");
    }


    public static void DepositModSFX(int depositLevel)
    {
        var depositInstance = RuntimeManager.CreateInstance("event:/SFX/FactoryRun/DepositMod");
        depositInstance.setParameterByName("depositLevel",depositLevel);
        depositInstance.start();
        depositInstance.release();
    }

    public static void SiphonModSFX(int isEmpty)
    {
        var siphonInstance = RuntimeManager.CreateInstance("event:/SFX/FactoryRun/SiphonMod");
        siphonInstance.setParameterByName("siphonIsEmpty", isEmpty);
        siphonInstance.start();
        siphonInstance.release();
    }

    public static void FlipSwitchTileSFX()
    {
        RuntimeManager.PlayOneShot("event:/SFX/FactoryRun/FlipSwitchTile");
    }

    public static void RotateTileSFX()
    {
        RuntimeManager.PlayOneShot("event:/SFX/FactoryRun/RotateTile");
    }




}
