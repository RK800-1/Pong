using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for
/// the tap audio
/// </summary>
public class TapAudio : MonoBehaviour
{
    [SerializeField] protected GameObject audioComponent;
    [SerializeField] protected AudioSource tapSound;
    [SerializeField] protected AudioClip tapClip;

    DontDestroy dontDestroy;

    private void Awake()
    {
        if (!FindObjectOfType<TapAudio>())
        {
            dontDestroy.DoNotDestroy();
        }
    }

    void Start()
    {
        tapSound = audioComponent.GetComponent<AudioSource>();
    }

    public void PlayTap()
    {
        tapSound.PlayOneShot(tapClip);
    }
}
