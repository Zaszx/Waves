using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public List<Letter> letters = new List<Letter>();
    public int currentIndex;
    public float moveAmountPerSecond;
    public float moveAmountAdjustment;
    
    // UI
    public Transform LettersParent;
    public AnimationCurve WaveRailShape; // maybe..

    public void Init()
    {
        currentIndex = 0;
        moveAmountPerSecond = Screen.width * 0.5f * 0.06f;
        moveAmountAdjustment = 1.0f;

        Reset();
    }

    public void Tick()
    {
        var moveAmountThisFrame = moveAmountPerSecond * Time.deltaTime;
        moveAmountThisFrame *= Globals.isPlayerOneTurn ? -1 : 1;
        transform.position += moveAmountThisFrame * Vector3.right * moveAmountAdjustment;
    }

    public bool CheckLose(out bool isPlayerOneWinner)
    {
        if(transform.position.x < 0)
        {
            isPlayerOneWinner = false;
            return true;
        }
        else if (transform.position.x > Screen.width)
        {
            isPlayerOneWinner = true;
            return true;
        }
        isPlayerOneWinner = false;
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

        CreateLetterWith(KeyCode.Alpha3, true);
    }

    public void Reverse(KeyCode newKeyCode)
    {
        Letter currentLetter = letters[currentIndex - 1];
        currentLetter.SetKey(newKeyCode);

        moveAmountAdjustment = 1.0f;
        currentIndex = 0;

        CreateLetterWith(KeyCode.Alpha5, true);

        foreach (var letter in letters)
        {
            letter.SetStatus(LetterStatus.TBD);
            if(!letter.isJoker)
            {
                letter.SetKey(Globals.keyCodePairs[letter.key]);
            }
        }
    }

    private void CreateLetterWith(KeyCode keyCode, bool isJoker)
    {
        var newLetter = Instantiate(Prefabs.letter).GetComponent<Letter>();
        newLetter.isJoker = isJoker;
        newLetter.transform.SetParent(LettersParent);
        newLetter.key = keyCode;
        letters.Add(newLetter);
    }

    public KeyCode GetNextKey()
    {
        return letters[currentIndex].key;
    }

    public void ResetAfterFailedKey()
    {
        currentIndex = 0;
        for (int i = 0; i < letters.Count - 1; i++)
        {
            Letter l = letters[i];
            l.SetStatus(LetterStatus.TBD);
        }
    }

    public void HandleSuccessInput()
    {
        var currentLetter = letters[currentIndex];
        currentLetter.SetStatus(LetterStatus.Success);

        currentIndex++;
    }

    public Letter GetNextLetter()
    {
        return letters[currentIndex];
    }

    public void HandleFailedInput()
    {
        var currentLetter = letters[currentIndex];
        currentLetter.SetStatus(LetterStatus.Fail);
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
