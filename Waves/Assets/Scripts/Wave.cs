using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public List<Letter> letters = new List<Letter>();
    public int currentIndex;
    public float moveAmountPerSecond;
    
    // UI
    public Transform LettersParent;
    public AnimationCurve WaveRailShape;

    public void Init()
    {
        currentIndex = 0;
        moveAmountPerSecond = Screen.width * 0.5f * 0.1f;

        Reset();
    }

    public void Tick()
    {
        var moveAmountThisFrame = moveAmountPerSecond * Time.deltaTime;
        moveAmountThisFrame *= Globals.isPlayerOneTurn ? 1 : -1;
        transform.position += moveAmountThisFrame * Vector3.right;
    }

    public bool CheckLose()
    {
        if(transform.position.x < 0 || transform.position.x > Screen.width)
        {
            return true;
        }
        return false;
    }

    public void Reset()
    {
        foreach(var letter in letters)
        {
            Destroy(letter.gameObject);
        }
        letters.Clear();
        currentIndex = 0;

        var newLetter = Instantiate(Prefabs.letter).GetComponent<Letter>();
        newLetter.isJoker = false;
        newLetter.transform.SetParent(LettersParent);
        newLetter.key = KeyCode.W;
        letters.Add(newLetter);
    }

    public void Reverse(KeyCode newKeyCode)
    {
        currentIndex = 0;
        var newLetter = Instantiate(Prefabs.letter).GetComponent<Letter>();
        newLetter.isJoker = false;
        newLetter.transform.SetParent(LettersParent);
        newLetter.key = newKeyCode;
        letters.Add(newLetter);

        foreach(var letter in letters)
        {
            letter.SetStatus(LetterStatus.TBD);
            if(!letter.isJoker)
            {
                letter.SetKey(Globals.keyCodePairs[letter.key]);
            }
        }

    }

    public KeyCode GetNextKey()
    {
        return letters[currentIndex].key;
    }

    public void HandleInputResult(InputResult inputResult)
    {
        var currentLetter = letters[currentIndex];

        if (inputResult == InputResult.Correct)
        {
            currentLetter.SetStatus(LetterStatus.Success);

            currentIndex++;
        }
        else if (inputResult == InputResult.Wrong)
        {
            currentLetter.SetStatus(LetterStatus.Fail);

        }
    }

    public bool CheckKeysSuccess()
    {
        if(currentIndex == letters.Count)
        {
            return true;
        }
        return false;
    }
}
