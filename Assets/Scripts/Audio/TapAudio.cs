using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for
/// the tap audio
/// </summary>
public class TapAudio : MonoBehaviour
{
    [SerializeField] protected AudioSource tapSound;
    [SerializeField] protected AudioClip tapClip;

    public void PlayTap()
    {
        tapSound.PlayOneShot(tapClip);
    }
}
