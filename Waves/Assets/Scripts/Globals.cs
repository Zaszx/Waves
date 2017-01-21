using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static bool isPlayerOneTurn;
    public static Dictionary<KeyCode, KeyCode> keyCodePairs;

    public static Dictionary<KeyCode, KeyCode> keyboardToJoystickMap;

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

        keyboardToJoystickMap = new Dictionary<KeyCode, KeyCode>();
        keyboardToJoystickMap[KeyCode.W] = KeyCode.Joystick1Button0;
        keyboardToJoystickMap[KeyCode.D] = KeyCode.Joystick1Button1;
        keyboardToJoystickMap[KeyCode.S] = KeyCode.Joystick1Button2;
        keyboardToJoystickMap[KeyCode.A] = KeyCode.Joystick1Button3;
        
        keyboardToJoystickMap[KeyCode.UpArrow] = KeyCode.Joystick2Button0;
        keyboardToJoystickMap[KeyCode.RightArrow] = KeyCode.Joystick2Button1;
        keyboardToJoystickMap[KeyCode.DownArrow] = KeyCode.Joystick2Button2;
        keyboardToJoystickMap[KeyCode.LeftArrow] = KeyCode.Joystick2Button3;

        keyboardToJoystickMap[KeyCode.Alpha3] = KeyCode.Alpha3;
        keyboardToJoystickMap[KeyCode.Alpha5] = KeyCode.Alpha5;
        keyboardToJoystickMap[KeyCode.Space] = KeyCode.Space;

        //keyCodePairs[KeyCode.W] = KeyCode.Joystick1Button0;
        //keyCodePairs[KeyCode.D] = KeyCode.Joystick1Button1;
        //keyCodePairs[KeyCode.S] = KeyCode.Joystick1Button2;
        //keyCodePairs[KeyCode.A] = KeyCode.Joystick1Button3;

        //keyCodePairs[KeyCode.Joystick1Button0] = KeyCode.W;
        //keyCodePairs[KeyCode.Joystick1Button1] = KeyCode.D;
        //keyCodePairs[KeyCode.Joystick1Button2] = KeyCode.S;
        //keyCodePairs[KeyCode.Joystick1Button3] = KeyCode.A;
    }
}
