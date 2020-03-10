using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip music;
    public AudioSource musicSource;
    public AudioClip[] soundEffects;
    public AudioSource soundSource;

    private void Start()
    {
        musicSource.volume = 1;
        soundSource.volume = 1;
        musicSource.clip = music;
        musicSource.Play();
    }
    public void musicSettings(int volume)
    {
        musicSource.volume = volume;
    }
    public void SeSettings(int volume)
    {
        soundSource.volume = volume;
    }
}
