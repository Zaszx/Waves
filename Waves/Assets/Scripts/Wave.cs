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
        newLetter.isJoker = true;
        newLetter.transform.SetParent(LettersParent);
        letters.Add(newLetter);
    }

    public void Reverse(KeyCode newKeyCode)
    {
        Letter currentLetter = letters[currentIndex - 1];
        currentLetter.SetKey(newKeyCode);

        currentIndex = 0;
        var newLetter = Instantiate(Prefabs.letter).GetComponent<Letter>();
        newLetter.isJoker = true;
        newLetter.transform.SetParent(LettersParent);
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

    public Letter GetNextLetter()
    {
        return letters[currentIndex];
    }

    public KeyCode GetNextKey()
    {
        return letters[currentIndex].key;
    }

    public void HandleInputResult(InputResultState inputResult)
    {
        var currentLetter = letters[currentIndex];

        if (inputResult == InputResultState.Correct)
        {
            currentLetter.SetStatus(LetterStatus.Success);

            currentIndex++;
        }
        else if (inputResult == InputResultState.Wrong)
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
