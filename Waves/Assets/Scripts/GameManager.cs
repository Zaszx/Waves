using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Wave wave;
    public Ui Ui;
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

	    bool isPlayerOneWinner;
        if(wave.CheckLose(out isPlayerOneWinner))
        {
            Ui.GameOver(isPlayerOneWinner);
        }

        var result = inputManager.GetInputResult(wave.GetNextKey());
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
