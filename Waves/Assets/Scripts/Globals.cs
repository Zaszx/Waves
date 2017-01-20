using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static bool isPlayerOneTurn;
    public static Dictionary<KeyCode, KeyCode> keyCodePairs;

    public static void Init()
    {
        isPlayerOneTurn = true;

        keyCodePairs = new Dictionary<KeyCode, KeyCode>();
        keyCodePairs[KeyCode.W] = KeyCode.UpArrow;
        keyCodePairs[KeyCode.A] = KeyCode.LeftArrow;
        keyCodePairs[KeyCode.S] = KeyCode.DownArrow;
        keyCodePairs[KeyCode.D] = KeyCode.RightArrow;

        keyCodePairs[KeyCode.UpArrow] = KeyCode.W;
        keyCodePairs[KeyCode.LeftArrow] = KeyCode.A;
        keyCodePairs[KeyCode.DownArrow] = KeyCode.S;
        keyCodePairs[KeyCode.RightArrow] = KeyCode.D;

    }
}
