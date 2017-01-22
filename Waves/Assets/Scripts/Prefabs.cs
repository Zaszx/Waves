using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public static class Prefabs
{
    public static GameObject letter;
    //public static GameObject kazik;

    public static GameObject[] items;

    static Prefabs()
    {
        letter = Resources.Load<GameObject>("Prefabs/Letter");
        //kazik = Resources.Load<GameObject>("Prefabs/Kazik");

        items = new[]
        {
            //Resources.Load<GameObject>("Prefabs/Kazik"),
            Resources.Load<GameObject>("Prefabs/Club"),
            Resources.Load<GameObject>("Prefabs/Sems"),
            Resources.Load<GameObject>("Prefabs/Tokmak"),
            Resources.Load<GameObject>("Prefabs/WalkingCane"),
            Resources.Load<GameObject>("Prefabs/Zopa"),
            Resources.Load<GameObject>("Prefabs/Kol"),
        };
    }
}
