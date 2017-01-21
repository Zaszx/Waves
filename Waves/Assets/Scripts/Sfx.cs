using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class Sfx
{
    public static T Random<T>(this IList<T> lst)
    {
        return lst[UnityEngine.Random.Range(0, lst.Count)];
    }

    public static AudioClip[] WheelSpins;
    public static AudioClip[] WheelSelects;
    public static AudioClip[] Countdowns;
    public static AudioClip[] SequenceCompletedLights;
    public static AudioClip[] SequenceCompletedMediums;
    public static AudioClip[] SequenceCompletedHeavys;
    public static AudioClip[] GirmeyeYaklastis;
    public static AudioClip[] BonusCompleteds;
    public static AudioClip[] Girdis;

    private static readonly AudioSource AudioSource;

    static Sfx()
    {
        AudioSource = Camera.main.GetComponent<AudioSource>();

        WheelSpins = new[]
        {
            Resources.Load<AudioClip>("Sfx/WheelSpins/WheelSpin1"),
            Resources.Load<AudioClip>("Sfx/WheelSpins/WheelSpin2"),
            Resources.Load<AudioClip>("Sfx/WheelSpins/WheelSpin3"),
        };

        WheelSelects = new[]
        {
            Resources.Load<AudioClip>("Sfx/WheelSpins/WheelSelects1"),
            Resources.Load<AudioClip>("Sfx/WheelSpins/WheelSelects2"),
            Resources.Load<AudioClip>("Sfx/WheelSpins/WheelSelects3"),
        };

        Countdowns = new[]
        {
            Resources.Load<AudioClip>("Sfx/Countdowns/Countdown1"),
            Resources.Load<AudioClip>("Sfx/Countdowns/Countdown2"),
            Resources.Load<AudioClip>("Sfx/Countdowns/Countdown3"),
        };

        SequenceCompletedLights = new[]
        {
            Resources.Load<AudioClip>("Sfx/SequenceCompletedLights/SequenceCompletedLight1"),
            Resources.Load<AudioClip>("Sfx/SequenceCompletedLights/SequenceCompletedLight2"),
            Resources.Load<AudioClip>("Sfx/SequenceCompletedLights/SequenceCompletedLight3"),
        };

        SequenceCompletedMediums = new[]
        {
            Resources.Load<AudioClip>("Sfx/SequenceCompletedMediums/SequenceCompletedMedium1"),
            Resources.Load<AudioClip>("Sfx/SequenceCompletedMediums/SequenceCompletedMedium2"),
            Resources.Load<AudioClip>("Sfx/SequenceCompletedMediums/SequenceCompletedMedium3"),
        };

        SequenceCompletedHeavys = new[]
        {
            Resources.Load<AudioClip>("Sfx/SequenceCompletedHeavys/SequenceCompletedHeavy1"),
            Resources.Load<AudioClip>("Sfx/SequenceCompletedHeavys/SequenceCompletedHeavy2"),
            Resources.Load<AudioClip>("Sfx/SequenceCompletedHeavys/SequenceCompletedHeavy3"),
        };

        GirmeyeYaklastis = new[]
        {
            Resources.Load<AudioClip>("Sfx/GirmeyeYaklastis/GirmeyeYaklasti1"),
            Resources.Load<AudioClip>("Sfx/GirmeyeYaklastis/GirmeyeYaklasti2"),
            Resources.Load<AudioClip>("Sfx/GirmeyeYaklastis/GirmeyeYaklasti3"),
        };

        BonusCompleteds = new[]
        {
            Resources.Load<AudioClip>("Sfx/BonusCompleteds/BonusCompleted1"),
            Resources.Load<AudioClip>("Sfx/BonusCompleteds/BonusCompleted2"),
            Resources.Load<AudioClip>("Sfx/BonusCompleteds/BonusCompleted3"),
        };

        Girdis = new[]
        {
            Resources.Load<AudioClip>("Sfx/Girdis/Girdi1"),
            Resources.Load<AudioClip>("Sfx/Girdis/Girdi2"),
            Resources.Load<AudioClip>("Sfx/Girdis/Girdi3"),
        };
    }

    public static void PlayWheelSpin()
    {
        AudioSource.PlayOneShot(WheelSpins.Random());
    }

    public static void PlayWheelSelect()
    {
        AudioSource.PlayOneShot(WheelSelects.Random());
    }

    public static void PlayCountdown()
    {
        AudioSource.PlayOneShot(Countdowns.Random());
    }

    public static void PlaySequenceCompletedLight()
    {
        AudioSource.PlayOneShot(SequenceCompletedLights.Random());
    }

    public static void PlaySequenceCompletedMedium()
    {
        AudioSource.PlayOneShot(SequenceCompletedMediums.Random());
    }

    public static void PlaySequenceCompletedHeavy()
    {
        AudioSource.PlayOneShot(SequenceCompletedHeavys.Random());
    }

    public static void PlayGirmeyeYaklasti()
    {
        AudioSource.PlayOneShot(GirmeyeYaklastis.Random());
    }
    public static void PlayBonusCompleted()
    {
        AudioSource.PlayOneShot(BonusCompleteds.Random());
    }

    public static void PlayGirdi()
    {
        AudioSource.PlayOneShot(Girdis.Random());
    }
}
