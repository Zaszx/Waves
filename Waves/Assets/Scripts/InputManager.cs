using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public static Dictionary<bool, List<KeyCode>> validKeyCodes = new Dictionary<bool, List<KeyCode>>();
    
    public void Init()
    {
        validKeyCodes.Clear();
        List<KeyCode> validKeysForPlayerOne = new List<KeyCode>();
        validKeysForPlayerOne.Add(KeyCode.W);
        validKeysForPlayerOne.Add(KeyCode.A);
        validKeysForPlayerOne.Add(KeyCode.S);
        validKeysForPlayerOne.Add(KeyCode.D);

        validKeyCodes[true] = validKeysForPlayerOne;

        List<KeyCode> validKeysForPlayerTwo = new List<KeyCode>();
        validKeysForPlayerTwo.Add(KeyCode.UpArrow);
        validKeysForPlayerTwo.Add(KeyCode.DownArrow);
        validKeysForPlayerTwo.Add(KeyCode.LeftArrow);
        validKeysForPlayerTwo.Add(KeyCode.RightArrow);

        validKeysForPlayerTwo.Add(KeyCode.Joystick1Button0);
        validKeysForPlayerTwo.Add(KeyCode.Joystick1Button1);
        validKeysForPlayerTwo.Add(KeyCode.Joystick1Button2);
        validKeysForPlayerTwo.Add(KeyCode.Joystick1Button3);


        validKeyCodes[false] = validKeysForPlayerTwo;
    }

    public void Tick()
    {

    }

    public InputResult GetInputResult(KeyCode expectedKey, bool isJoker, bool forPlayerOne)
    {
        if(Input.GetKeyDown(expectedKey))
        {
            return new InputResult(InputResultState.Correct, expectedKey);
        }
        else
        {
            foreach(KeyCode keyCode in validKeyCodes[forPlayerOne])
            {
                if(Input.GetKeyDown(keyCode))
                {
                    if(isJoker)
                    {
                        return new InputResult(InputResultState.Correct, keyCode);
                    }
                    else
                    {
                        return new InputResult(InputResultState.Wrong, keyCode);
                    }
                }
            }
        }
        return new InputResult(InputResultState.Blank, KeyCode.Space);
    }
}
