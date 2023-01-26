using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio : TapAudio
{
    public void PlayTap()
    {
        tapSound.PlayOneShot(tapClip);
    }
}
