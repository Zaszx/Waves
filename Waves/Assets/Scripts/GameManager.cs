using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Wheel,
    Countdown,
    Game,
    GameOver,
}

public class GameManager : MonoBehaviour
{
    public Wave wave;
    public Ui Ui;
    private readonly InputManager inputManager = new InputManager();
    public GameState gameState;
    public Items items = new Items();
    public Wheel wheel = new Wheel();

	void Start ()
    {
        Globals.Init();
        inputManager.Init();
        wave.Init();
        items.Init();

        SwitchState(GameState.Wheel);
    }
	
    public void SwitchState(GameState newState)
    {
        gameState = newState;
        wave.gameObject.SetActive(false);

        if (gameState == GameState.Countdown)
        {
            wave.gameObject.SetActive(true);
            StartCoroutine(CountdownCoroutine());
        }
        else if(gameState == GameState.Wheel)
        {
            StartCoroutine(SpinWheel());
        }
        else if(gameState == GameState.Game)
        {
            wave.gameObject.SetActive(true);
        }
    }

    public IEnumerator SpinWheel()
    {
        yield return StartCoroutine(wheel.Spin(items, Ui));
        SwitchState(GameState.Countdown);
    }

    public IEnumerator CountdownCoroutine()
    {
        float accumulatedTime = 0;
        float totalTime = 1.0f;

        for(int i = 3; i > 0; i--)
        {
            accumulatedTime = 0;
            while(accumulatedTime < totalTime)
            {
                Ui.CountdownText.text = "" + i;
                Ui.CountdownText.fontSize = (int)(40 + (1 - (accumulatedTime / totalTime)) * 30);
                yield return new WaitForEndOfFrame();
                accumulatedTime = accumulatedTime + Time.deltaTime;
            }
        }

        SwitchState(GameState.Game);

        Ui.CountdownText.text = "GO!";
        yield return new WaitForSeconds(1.0f);
        Ui.CountdownText.text = "";
    }

	void Update ()
    {
        if(gameState == GameState.Game)
        {
            wave.Tick();
            bool isPlayerOneWinner;
            if (wave.CheckLose(out isPlayerOneWinner))
            {
                SwitchState(GameState.GameOver);
                Ui.GameOver(isPlayerOneWinner);
            }

            var result = inputManager.GetInputResult(wave.GetNextLetter().key, wave.GetNextLetter().isJoker);
            HandleInputResult(result);

            if (wave.CheckKeysSuccess())
            {
                wave.Reverse(result.pressedKey);
                Globals.isPlayerOneTurn = !Globals.isPlayerOneTurn;
            }
        }


	}
    
    void HandleInputResult(InputResult result)
    {
        if(result.inputResultState == InputResultState.Correct)
        {
            wave.HandleSuccessInput();
        }
        else if(result.inputResultState == InputResultState.Wrong)
        {
            wave.HandleFailedInput();
            StartCoroutine(OnFailedInput());
        }
    }

    public IEnumerator OnFailedInput()
    {
        inputManager.isResponsive = false;
        yield return new WaitForSeconds(1.0f);
        wave.ResetAfterFailedKey();
        inputManager.isResponsive = true;
    }

}
