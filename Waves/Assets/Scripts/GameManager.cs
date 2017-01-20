using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Wave wave;
    InputManager inputManager = new InputManager();

	void Start ()
    {
        Globals.isPlayerOneTurn = true;
        inputManager.Init();

    }
	
	void Update ()
    {
        wave.Tick();

        if(wave.CheckLose())
        {

        }

        InputResult result = inputManager.GetInputResult(wave.GetNextKey());
        if(result == InputResult.Correct)
        {
            wave.currentIndex++;
        }
        else if(result == InputResult.Wrong)
        {

        }

        if(wave.CheckKeysSuccess())
        {
            wave.Reverse(KeyCode.W);
            Globals.isPlayerOneTurn = !Globals.isPlayerOneTurn;
        }


	}
}
