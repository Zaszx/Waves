using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefabs
{
    public static GameObject letter;
    public static GameObject kazik;

    static Prefabs()
    {
        letter = Resources.Load<GameObject>("Prefabs/Letter");
        kazik = Resources.Load<GameObject>("Prefabs/Kazik");
    }
}
