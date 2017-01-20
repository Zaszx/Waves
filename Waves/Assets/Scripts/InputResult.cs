using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputResultState
{
    Correct,
    Wrong,
    Blank,
}

public class InputResult
{
    public InputResultState inputResultState;
    public KeyCode pressedKey;

    public InputResult(InputResultState inputResultState, KeyCode pressedKey)
    {
        this.inputResultState = inputResultState;
        this.pressedKey = pressedKey;
    }
}
