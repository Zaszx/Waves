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

    private static AudioSource AudioSource;

    public static void Init()
    {
        AudioSource = Camera.main.GetComponent<AudioSource>();

        WheelSpins = new[]
        {
            Resources.Load<AudioClip>("Sfx/wheelspin_loop_01"),
        };

        WheelSelects = new[]
        {
            Resources.Load<AudioClip>("Sfx/wheelselect_01"),
            Resources.Load<AudioClip>("Sfx/wheelselect_02"),
            Resources.Load<AudioClip>("Sfx/wheelselect_03"),
            Resources.Load<AudioClip>("Sfx/wheelselect_04"),
            Resources.Load<AudioClip>("Sfx/wheelselect_05"),
            Resources.Load<AudioClip>("Sfx/wheelselect_06"),
        };

        Countdowns = new[]
        {
            Resources.Load<AudioClip>("Sfx/countdown_01"),
            Resources.Load<AudioClip>("Sfx/countdown_02"),
            Resources.Load<AudioClip>("Sfx/countdown_03"),
            Resources.Load<AudioClip>("Sfx/countdown_04"),
            Resources.Load<AudioClip>("Sfx/countdown_05"),
            Resources.Load<AudioClip>("Sfx/countdown_06"),
            Resources.Load<AudioClip>("Sfx/countdown_07"),
        };

        SequenceCompletedLights = new[]
        {
            Resources.Load<AudioClip>("Sfx/success_low_01"),
            Resources.Load<AudioClip>("Sfx/success_low_02"),
            Resources.Load<AudioClip>("Sfx/success_low_03"),
            Resources.Load<AudioClip>("Sfx/success_low_04"),
            Resources.Load<AudioClip>("Sfx/success_low_05"),
        };

        SequenceCompletedMediums = new[]
        {
            Resources.Load<AudioClip>("Sfx/success_mid_01"),
            Resources.Load<AudioClip>("Sfx/success_mid_02"),
            Resources.Load<AudioClip>("Sfx/success_mid_03"),
            Resources.Load<AudioClip>("Sfx/success_mid_04"),
            Resources.Load<AudioClip>("Sfx/success_mid_05"),
            Resources.Load<AudioClip>("Sfx/success_mid_06"),
        };

        SequenceCompletedHeavys = new[]
        {
            Resources.Load<AudioClip>("Sfx/SequenceCompletedHeavys/SequenceCompletedHeavy1"),
            Resources.Load<AudioClip>("Sfx/SequenceCompletedHeavys/SequenceCompletedHeavy2"),
            Resources.Load<AudioClip>("Sfx/SequenceCompletedHeavys/SequenceCompletedHeavy3"),
        };

        GirmeyeYaklastis = new[]
        {
            Resources.Load<AudioClip>("Sfx/closer_01"),
            Resources.Load<AudioClip>("Sfx/closer_02"),
            Resources.Load<AudioClip>("Sfx/closer_03"),
            Resources.Load<AudioClip>("Sfx/closer_04"),
            Resources.Load<AudioClip>("Sfx/closer_05"),
        };

        BonusCompleteds = new[]
        {
            Resources.Load<AudioClip>("Sfx/bonus_complete_01"),
            Resources.Load<AudioClip>("Sfx/bonus_complete_02"),
            Resources.Load<AudioClip>("Sfx/bonus_complete_03"),
            Resources.Load<AudioClip>("Sfx/bonus_complete_04"),
            Resources.Load<AudioClip>("Sfx/bonus_complete_05"),
        };

        Girdis = new[]
        {
            Resources.Load<AudioClip>("Sfx/hasirt_01"),
            Resources.Load<AudioClip>("Sfx/hasirt_02"),
            Resources.Load<AudioClip>("Sfx/hasirt_03"),
            Resources.Load<AudioClip>("Sfx/hasirt_04"),
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
