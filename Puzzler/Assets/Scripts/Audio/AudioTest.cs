using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;



public class AudioTest : MonoBehaviour
{
    public bool playMusic;
    FMOD.Studio.EventInstance musicEvent;
    // Start is called before the first frame update
    void Start()
    {
        if (playMusic == true)
        {
            musicEvent = RuntimeManager.CreateInstance("event:/MUSIC/TestMusic");
            musicEvent.start();
            musicEvent.release();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
