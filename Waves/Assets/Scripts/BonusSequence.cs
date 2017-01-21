using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusSequence
{
    public List<Letter> letters = new List<Letter>();
    public GameObject rootObject;
    public Text rootUiText;
    int currentLetterIndex;

    public void Clear()
    {
        currentLetterIndex = 0;
        foreach(Letter l in letters)
        {
            GameObject.Destroy(l.gameObject);
        }
        letters.Clear();

        if(rootUiText)
        {
            rootUiText.gameObject.SetActive(false);
        }
    }

    public void InitBonusSequence(GameObject rootObject, Text rootUiText, int length, bool isForPlayerOne)
    {
        Clear();

        this.rootObject = rootObject;
        this.rootUiText = rootUiText;

        rootObject.SetActive(true);
        rootUiText.gameObject.SetActive(true);

        List<KeyCode> validKeyCodes = InputManager.validKeyCodes[isForPlayerOne];
        for(int i = 0; i < length; i++)
        {
            int index = Random.Range(0, validKeyCodes.Count - 1);
            KeyCode keyCodeToAdd = validKeyCodes[index];
            CreateLetterWith(keyCodeToAdd, false);
        }
    }

    private void CreateLetterWith(KeyCode keyCode, bool isJoker)
    {
        var newLetter = GameObject.Instantiate(Prefabs.letter).GetComponent<Letter>();
        newLetter.isJoker = isJoker;
        newLetter.transform.SetParent(rootObject.transform);
        newLetter.SetKey(keyCode);
        newLetter.SetStatus(LetterStatus.TBD);
        letters.Add(newLetter);
    }

    public Letter GetNextLetter()
    {
        return letters[currentLetterIndex];
    }

    public bool CheckFinished()
    {
        return currentLetterIndex == letters.Count;
    }

    public void HandleSuccess()
    {
        Letter currentLetter = letters[currentLetterIndex];
        currentLetter.SetStatus(LetterStatus.Success);

        currentLetterIndex++;
    }

    public void HandleFail()
    {
        Letter currentLetter = letters[currentLetterIndex];
        currentLetter.SetStatus(LetterStatus.Fail);
    }
}
