using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Wave wave;
    private readonly InputManager inputManager = new InputManager();

	void Start ()
    {
        Globals.Init();
        inputManager.Init();
        wave.Init();
    }
	
	void Update ()
    {
        wave.Tick();

        if(wave.CheckLose())
        {

        }

        var result = inputManager.GetInputResult(wave.GetNextLetter().key, wave.GetNextLetter().isJoker);
        wave.HandleInputResult(result.inputResultState);

        if(wave.CheckKeysSuccess())
        {
            wave.Reverse(result.pressedKey);
            Globals.isPlayerOneTurn = !Globals.isPlayerOneTurn;
        }


	}
}
