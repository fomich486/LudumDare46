using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource soundSource;
    public AudioSource windAudioSource;
    public AudioData audioData;
    public static void PlaySound(AudioClip sound)
    {
        Instance.soundSource.PlayOneShot(sound);
    }
}
