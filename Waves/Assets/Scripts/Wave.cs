using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public List<Letter> letters = new List<Letter>();
    public int currentIndex;
    public float moveAmountPerSecond;




    public void Start()
    {
        currentIndex = 0;
        moveAmountPerSecond = Screen.width * 0.5f * 0.1f;

        Reset();
    }

    public void Tick()
    {
        float moveAmountThisFrame = moveAmountPerSecond * Time.deltaTime;
        moveAmountThisFrame *= Globals.isPlayerOneTurn ? 1 : -1;
        GetComponent<RectTransform>().position += moveAmountThisFrame * Vector3.right;
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
        foreach(Letter l in letters)
        {
            GameObject.Destroy(l.gameObject);
        }
        letters.Clear();
        currentIndex = 0;

        Letter newLetter = GameObject.Instantiate(Prefabs.letter).GetComponent<Letter>();
        newLetter.isJoker = false;
        newLetter.transform.parent = this.transform;
        newLetter.key = KeyCode.W;
        letters.Add(newLetter);
    }

    public void Reverse(KeyCode newKeyCode)
    {
        currentIndex = 0;
        Letter newLetter = GameObject.Instantiate(Prefabs.letter).GetComponent<Letter>();
        newLetter.isJoker = false;
        newLetter.transform.parent = this.transform;
        newLetter.key = newKeyCode;
        letters.Add(newLetter);

        foreach(Letter l in letters)
        {
            l.SetStatus(LetterStatus.TBD);
            if(l.isJoker == false)
            {
                l.SetKey(Globals.keyCodePairs[l.key]);
            }
        }

        UpdateLetterPositions();
    }

    public void UpdateLetterPositions()
    {

    }

    public KeyCode GetNextKey()
    {
        return letters[currentIndex].key;
    }

    public void HandleInputResult(InputResult inputResult)
    {
        Letter currentLetter = letters[currentIndex];

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
