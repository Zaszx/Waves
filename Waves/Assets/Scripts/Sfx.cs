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
            Resources.Load<AudioClip>("Sfx/WheelSpins/WheelSelects"),
            Resources.Load<AudioClip>("Sfx/WheelSpins/WheelSelects"),
            Resources.Load<AudioClip>("Sfx/WheelSpins/WheelSelects"),
        };

        // ...

    }

    public static void PlayWheelSpin()
    {
        AudioSource.PlayOneShot(WheelSpins.Random());
    }
}
