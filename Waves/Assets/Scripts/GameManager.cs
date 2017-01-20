﻿using System.Collections;
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
