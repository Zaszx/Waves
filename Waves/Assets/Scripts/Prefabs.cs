using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefabs
{
    public static GameObject letter;

    static Prefabs()
    {
        letter = Resources.Load<GameObject>("Prefabs/Letter");
    }
}
