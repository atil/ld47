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
    public AudioSource WalkAudioSource;
    public AudioSource OtherAudioSource;
    public AudioSource MusicAudioSource;
    public AudioSource GlitchAudioSource;
    public AudioSource TimedBendAudioSource;

    [Space]

    public AudioClip JumpClip;
    public AudioClip LandClip;
    public AudioClip LandFromHeightClip;
    public AudioClip BenderHit;
    public AudioClip BendClip;
    public AudioClip UnbendClip;
    public AudioClip EmptyFireClip;
    public AudioClip ClickClip;
    public AudioClip TeleportClip;
    public AudioClip AimBenderClip;
    public AudioClip AimGravityClip;
    public AudioClip CollectibleClip;
    public AudioClip ButtonClip;
    public AudioClip UiMessageClip;
    public AudioClip JumpPadClip;
    public AudioClip GravityClip;
    public AudioClip GravityPickupClip;
    public AudioClip GlitchClip1;
    public AudioClip GlitchClip2;
    public AudioClip CheckpointClip;
    public AudioClip ItemCollectClip;
    public AudioClip ItemPlaceClip;
    public AudioClip WeaponCollectClip;
    public AudioClip LevelStartClip;

    public List<AudioClip> Footsteps;

    void Start()
    {
#if !AUDIO_ENABLED
        MusicAudioSource.volume = 0;
#endif
    }

    public void OnMusicVolumeChanged(float normalizedValue)
    {
        MusicAudioSource.volume = normalizedValue;
    }

    public void OnSfxVolumeChanged(float normalizedValue)
    {
        OtherAudioSource.volume = normalizedValue;
    }

    public void GlitchStart(GlitchSfxType sfxType)
    {
        if (sfxType == GlitchSfxType.Regular)
        {
            GlitchAudioSource.clip = GlitchClip1;
        }
        else if (sfxType == GlitchSfxType.End)
        {
            GlitchAudioSource.clip = GlitchClip2;
        }
        GlitchAudioSource.Play();
    }

    public void GlitchEnd()
    {
        GlitchAudioSource.Stop();
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

    public void FireOnBender()
    {
#if AUDIO_ENABLED
        OtherAudioSource.PlayOneShot(BenderHit);
#endif
    }

    public void Bend()
    {
#if AUDIO_ENABLED
        OtherAudioSource.PlayOneShot(BendClip);
#endif
        return;
    }

    public void Unbend()
    {
#if AUDIO_ENABLED
        OtherAudioSource.PlayOneShot(UnbendClip);
#endif
        return;
        
    }

    public void EmptyFire()
    {
        OtherAudioSource.PlayOneShot(EmptyFireClip);
    }

    public void Click()
    {
        OtherAudioSource.PlayOneShot(ClickClip);
    }

    public void Teleport()
    {
        OtherAudioSource.PlayOneShot(TeleportClip);
    }

    public void AimBender()
    {
        OtherAudioSource.PlayOneShot(AimBenderClip);
    }

    public void AimGravity()
    {
        OtherAudioSource.PlayOneShot(AimGravityClip);
    }

    public void Collectible()
    {
        OtherAudioSource.PlayOneShot(CollectibleClip);
    }

    public void Button()
    {
        OtherAudioSource.PlayOneShot(ButtonClip);
    }

    public void UiMessage()
    {
        OtherAudioSource.PlayOneShot(UiMessageClip);
    }

    public void JumpPad()
    {
        OtherAudioSource.PlayOneShot(JumpPadClip);
    }

    public void Gravity()
    {
        OtherAudioSource.PlayOneShot(GravityClip);
    }

    public void GravityPickup()
    {
        OtherAudioSource.PlayOneShot(GravityPickupClip);
    }

    public void Checkpoint()
    {
        OtherAudioSource.PlayOneShot(CheckpointClip);
    }

    public void LevelStart()
    {
        OtherAudioSource.PlayOneShot(LevelStartClip);
    }

    public void ItemPlace()
    {
        OtherAudioSource.PlayOneShot(ItemPlaceClip);
    }
    public void ItemCollect()
    {
        OtherAudioSource.PlayOneShot(ItemCollectClip);
    }

    public void WeaponCollect()
    {
        OtherAudioSource.PlayOneShot(WeaponCollectClip);
    }

    public void TimedBend(float duration)
    {
        StartCoroutine(TimedBendCoroutine(duration));
    }

    public void StopTimedBend()
    {
        TimedBendAudioSource.Pause();
    }

    private IEnumerator TimedBendCoroutine(float duration)
    {
        TimedBendAudioSource.Play();

        yield return new WaitForSeconds(duration);

        StopTimedBend();
    }
}

