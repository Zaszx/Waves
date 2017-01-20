using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Wave wave;
    InputManager inputManager = new InputManager();

	void Start ()
    {
        Globals.Init();
        inputManager.Init();

    }
	
	void Update ()
    {
        wave.Tick();

        if(wave.CheckLose())
        {

        }

        InputResult result = inputManager.GetInputResult(wave.GetNextKey());
        wave.HandleInputResult(result);



        if(wave.CheckKeysSuccess())
        {
            if(Globals.isPlayerOneTurn)
            {
                wave.Reverse(KeyCode.W);
            }
            else
            {
                wave.Reverse(KeyCode.UpArrow);
            }
            Globals.isPlayerOneTurn = !Globals.isPlayerOneTurn;
        }


	}
}
