using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for
/// the ball hit audio
/// </summary>
public class BallHitAudio : TapAudio
{
    public void PlayBallHit()
    {
        tapSound.PlayOneShot(tapClip);
    }
}
