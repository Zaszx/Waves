using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LetterStatus
{
    TBD,
    Success,
    Fail,
}

public class Letter : MonoBehaviour
{
    public KeyCode key;
    public bool isJoker;
    LetterStatus status;


    public void SetKey(KeyCode key)
    {
        this.key = key;
        UpdateImage();
    }

	void Start ()
    {
        status = LetterStatus.TBD;
	}
	
	void Update ()
    {
		
	}

    public void SetStatus(LetterStatus newStatus)
    {
        status = newStatus;
        UpdateImage();
    }

    public LetterStatus GetStatus()
    {
        return status;
    }

    void UpdateImage()
    {

    }
}
