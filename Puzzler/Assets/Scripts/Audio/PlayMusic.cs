using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    static bool hasPlayed = false;
    void Start()
    {
        if (!hasPlayed) { FactoryRunAudio.StartMusic(); hasPlayed = true; }
    }
}
