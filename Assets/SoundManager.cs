﻿using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    private AudioSource loopAudioSource;
    public float volume;

    public void Start()
    {
        volume = PlayerPrefs.GetFloat("SFXVol", 1);

        OnSoundsVolumeChanged(volume);

        Events.OnSoundFX += OnSoundFX;
    }
    void OnHeroDie()
    {
        OnSoundFXLoop("");
    }
    void OnDestroy()
    {
        Events.OnSoundFX -= OnSoundFX;
        if (loopAudioSource)
        {
            loopAudioSource = null;
            loopAudioSource.Stop();
        }
    }
    void OnSoundsVolumeChanged(float value)
    {
        audioSource.volume = value;
        volume = value;

        if (value == 0 || value == 1)
            PlayerPrefs.SetFloat("SFXVol", value);
    }
    void OnSoundFXLoop(string soundName)
    {
        if (volume == 0) return;

        if (!loopAudioSource)
            loopAudioSource = gameObject.AddComponent<AudioSource>() as AudioSource;

        if (soundName != "")
        {
            loopAudioSource.clip = Resources.Load("sound/" + soundName) as AudioClip;
            loopAudioSource.Play();
            loopAudioSource.loop = true;
        }
        else
        {
            loopAudioSource.Stop();
        }
    }
    void OnSoundFX(string soundName)
    {
        if (soundName == "")
        {
            audioSource.Stop();
            return;
        }

        if (!Data.Instance.soundsOn) return;
        print("_________________soundName: " + soundName);
        audioSource.PlayOneShot(Resources.Load("sound/" + soundName) as AudioClip);

    }
}
