using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputResult
{
    Correct,
    Wrong,
    Blank,

}

public class InputManager
{
    public Dictionary<bool, List<KeyCode>> validKeyCodes = new Dictionary<bool, List<KeyCode>>();
    public void Init()
    {
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

        validKeyCodes[false] = validKeysForPlayerTwo;
    }

    public void Tick()
    {

    }

    public InputResult GetInputResult(KeyCode expectedKey)
    {
        if(Input.GetKeyDown(expectedKey))
        {
            return InputResult.Correct;
        }
        else
        {
            foreach(KeyCode keyCode in validKeyCodes[Globals.isPlayerOneTurn])
            {
                if(Input.GetKeyDown(expectedKey))
                {
                    return InputResult.Wrong;
                }
            }
        }
        return InputResult.Blank;
    }
}
