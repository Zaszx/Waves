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
    public BonusSequence bonusSequence = new BonusSequence();

    public bool takeInputForWave = true;
    public bool takeInputForBonus = true;
    private bool _enterBonusSuccOnce = true;

    public bool dontPlayGirmeyeYaklasti = false;

	void Start ()
    {
        Globals.Init();
	    Sfx.Init();
        inputManager.Init();
        wave.Init();
        items.Init();

        takeInputForWave = true;
        takeInputForBonus = true;

        Ui.UpdateAvatarReactions(wave.transform.position.x / Screen.width);

        SwitchState(GameState.Wheel);

        dontPlayGirmeyeYaklasti = false;
    }
	
    public void SwitchState(GameState newState)
    {
        gameState = newState;
        wave.gameObject.SetActive(false);
        wave.LettersParent.gameObject.SetActive(false);

        if (gameState == GameState.Countdown)
        {
            wave.gameObject.SetActive(true);
            wave.LettersParent.gameObject.SetActive(true);

            StartCoroutine(CountdownCoroutine());
        }
        else if(gameState == GameState.Wheel)
        {
            StartCoroutine(SpinWheel());
        }
        else if(gameState == GameState.Game)
        {
            wave.gameObject.SetActive(true);
            wave.LettersParent.gameObject.SetActive(true);

        }
    }

    public IEnumerator SpinWheel()
    {
        yield return StartCoroutine(wheel.Spin(items, Ui));
        SwitchState(GameState.Countdown);
    }

    public IEnumerator CountdownCoroutine()
    {
        Sfx.PlayCountdown();

        float totalTime = 0.5f;
        Ui.CountdownText.gameObject.SetActive(true);
        for (int i = 3; i > 0; i--)
        {
            float accumulatedTime = 0;
            var initSize = Ui.CountdownText.rectTransform.sizeDelta;
            var targetSize = Ui.CountdownText.rectTransform.sizeDelta / 10f;
            while (accumulatedTime < totalTime)
            {
                Ui.CountdownText.sprite = Ui.countdownSprites[i];

                var t = Ui.CountdownTextSizeCurve.Evaluate(accumulatedTime / totalTime);
                Ui.CountdownText.rectTransform.sizeDelta = Vector2.Lerp(initSize, targetSize, t);

                //Ui.CountdownText.fontSize = (int)(40 + (1 - (accumulatedTime / totalTime)) * 30);
                yield return new WaitForEndOfFrame();
                accumulatedTime += Time.deltaTime;
            }
        }

        SwitchState(GameState.Game);

        Ui.CountdownText.sprite = Ui.countdownSprites[0];
        yield return new WaitForSeconds(1.0f);
        Ui.CountdownText.gameObject.SetActive(false);
    }

    public IEnumerator DontPlayGirmeyeYaklasti()
    {
        dontPlayGirmeyeYaklasti = true;
        yield return new WaitForSeconds(1.0f);
        dontPlayGirmeyeYaklasti = false;
    }

	void Update ()
    {
        float pressureAmount = Mathf.Abs(wave.transform.position.x / Screen.width - 0.5f) * 2.0f;

        Ui.UpdateAvatarReactions(wave.transform.position.x / Screen.width);

        if (gameState == GameState.Game)
        {
            if (pressureAmount > 0.9f && dontPlayGirmeyeYaklasti == false)
            {
                Sfx.PlayGirmeyeYaklasti();
                StartCoroutine(DontPlayGirmeyeYaklasti());
            }

            wave.Tick();
            bool isPlayerOneWinner;
            if (wave.CheckLose(out isPlayerOneWinner))
            {
                Sfx.PlayGirdi();
                StartCoroutine(ScreenShake(isPlayerOneWinner));
                //bonusSequence.Clear();
                //SwitchState(GameState.GameOver);
                //Ui.GameOver(isPlayerOneWinner);
            }
            InputResult result = new InputResult(InputResultState.Blank, KeyCode.Space);
            if(takeInputForWave)
            {
                result = inputManager.GetInputResult(wave.GetNextLetter().key, wave.GetNextLetter().isJoker,
                    Globals.isPlayerOneTurn);
            }
            HandleInputResult(result);

            InputResult bonusSequenceResult = new InputResult(InputResultState.Blank, KeyCode.Space);
            if(takeInputForBonus && bonusSequence.letters.Count > 0)
            {
                bonusSequenceResult = inputManager.GetInputResult(bonusSequence.GetNextLetter().key, false,
                    !Globals.isPlayerOneTurn);
            }
            if(bonusSequenceResult.inputResultState == InputResultState.Correct)
            {
                bonusSequence.HandleSuccess();
            }
            else if(bonusSequenceResult.inputResultState == InputResultState.Wrong)
            {
                bonusSequence.HandleFail();
                takeInputForBonus = false;
            }

            if (wave.CheckKeysSuccess())
            {
                _enterBonusSuccOnce = true;
                
                if (pressureAmount < 0.3f)
                {
                    Sfx.PlaySequenceCompletedLight();
                }
                else if(pressureAmount < 0.8f)
                {
                    Sfx.PlaySequenceCompletedMedium();
                }
                else
                {
                    Sfx.PlaySequenceCompletedHeavy();
                }

                wave.Reverse(result.pressedKey);
                bonusSequence.Clear();
                bonusSequence.InitBonusSequence(
                    Globals.isPlayerOneTurn ? Ui.PlayerOneBonusSequence : Ui.PlayerTwoBonusSequence,
                    Globals.isPlayerOneTurn ? Ui.PlayerOneBonusSequenceText : Ui.PlayerTwoBonusSequenceText,
                    wave.letters.Count + 5, 
                    Globals.isPlayerOneTurn);
                takeInputForBonus = true;
                Globals.isPlayerOneTurn = !Globals.isPlayerOneTurn;
            }

            if(bonusSequence.CheckFinished() 
                && bonusSequence.letters.Count > 0
                && _enterBonusSuccOnce)
            {
                _enterBonusSuccOnce = false;
                Sfx.PlayBonusCompleted();

                wave.moveAmountAdjustment = 4.0f;
                takeInputForBonus = false;
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
        takeInputForWave = false;
        yield return new WaitForSeconds(1.0f);
        wave.ResetAfterFailedKey();
        takeInputForWave = true;
    }

    IEnumerator ScreenShake(bool isPlayerOneWinner)
    {
        SwitchState(GameState.GameOver);

        const float duration = 2f;
        var magnitude = 10f;
        var initPos = Ui.Root.position;
        for (var f = 0f; f < duration; f += Time.deltaTime)
        {
            var r = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            Ui.Root.position = initPos + (r * magnitude * Mathf.Sign(Random.Range(-1f, 1f)));
            magnitude = Mathf.Lerp(10, 0, f / duration);
            yield return null;
        }

        Ui.Root.position = initPos;

        bonusSequence.Clear();
        Ui.GameOver(isPlayerOneWinner);
    }
}
