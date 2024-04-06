using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "TileSelectSO", menuName = "Create TileSelectSO")]


public class TileSelectAudio : ScriptableObject
{
    public static void TileSelectSFX()
    {
        RuntimeManager.PlayOneShot("event:/SFX/TileSelection/TileSelect");
    }
    public static void TileRotateSFX()
    {
        RuntimeManager.PlayOneShot("event:/SFX/TileSelection/TileRotate");
    }
    public static void TileDropSFX()
    {
        RuntimeManager.PlayOneShot("event:/SFX/TileSelection/TileDrop");
    }
    public static void TileDeleteSFX()
    {
        RuntimeManager.PlayOneShot("event:/SFX/TileSelection/TileDelete");
    }
}
