using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="UIAudioSO", menuName = "Create UIAudioSO")]

public class MenuAudio : ScriptableObject
{

    // ex of non-oneshot event call; can adjust parameters this way
    /*
   public bool playMusic;
   FMOD.Studio.EventInstance musicEvent;
  void Start()
   {
       if (playMusic == true)
       {
           musicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/MUSIC/TestMusic");
           musicEvent.start();
           musicEvent.release();
       }
   }*/

    public static void UIButtonClickSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI/UIButtonClick");
    }

}
