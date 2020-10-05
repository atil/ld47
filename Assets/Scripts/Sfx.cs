#define AUDIO_ENABLED

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GlitchSfxType
{
    Regular,
    End
}

public class Sfx : MonoBehaviour
{
    private static Sfx _instance;
    public static Sfx Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Sfx>();
            }
            return _instance;
        }
    }

    public AudioSource WalkAudioSource;
    public AudioSource OtherAudioSource;
    public AudioSource MusicAudioSource;
    public AudioSource GlitchAudioSource;
    public AudioSource TimedBendAudioSource;

    [Space]
    public AudioClip JumpClip;
    public AudioClip LandClip;
    public AudioClip LandFromHeightClip;
    public AudioClip ClickClip;
    public AudioClip ButtonClip;

    [Space]
    public AudioClip StoneFallClip;
    public AudioClip StoneImpactClip;
    public AudioClip StoneSlideClip;
    public AudioClip SquishClip;
    public AudioClip EarthquakeClip;
    public AudioClip GlitchClip;
    public AudioClip CarryableTakeClip;
    public AudioClip CarryablePutClip;

    public List<AudioClip> Footsteps;

    void Start()
    {
#if !AUDIO_ENABLED
        MusicAudioSource.volume = 0;
#endif
    }

    public void Jump()
    {
#if AUDIO_ENABLED
        OtherAudioSource.PlayOneShot(JumpClip);
#endif
        return;
    }

    public void Land()
    {
        OtherAudioSource.PlayOneShot(LandClip);
    }
    public void LandFromHeight()
    {
        OtherAudioSource.PlayOneShot(LandFromHeightClip);
    }

    public void Footstep()
    {
#if !AUDIO_ENABLED
        return;
#endif
        WalkAudioSource.PlayOneShot(Footsteps[0]);

        var playedSound = Footsteps[0];

        Footsteps.RemoveAt(0);
        Footsteps.Shuffle();
        Footsteps.Add(playedSound);
    }

    public void Squish()
    {
        OtherAudioSource.PlayOneShot(SquishClip);
    }

    public void Click()
    {
        OtherAudioSource.PlayOneShot(ClickClip);
    }

    public void Earthquake()
    {
        OtherAudioSource.PlayOneShot(EarthquakeClip);
    }

    public void Glitch()
    {
        OtherAudioSource.PlayOneShot(GlitchClip);
    }

    public void CarryableTake()
    {
        OtherAudioSource.PlayOneShot(CarryableTakeClip);
    }

    public void CarryablePut()
    {
        OtherAudioSource.PlayOneShot(CarryablePutClip);
    }

    public void Button()
    {
        OtherAudioSource.PlayOneShot(ButtonClip);
    }
}