using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public LetterStatus Status { get; private set; }

    public Image ForegroundImage;
    public Image BackgroundImage;

    public Sprite UpImage;
    public Sprite DownImage;
    public Sprite LeftImage;
    public Sprite RightImage;

    void Start()
    {
        Status = LetterStatus.TBD;
        BackgroundImage.color = Color.clear;
    }

    public void SetKey(KeyCode k)
    {
        key = k;

        isJoker = false;

        switch (k)
        {
            case KeyCode.W:
            case KeyCode.UpArrow:
                ForegroundImage.sprite = UpImage;
                break;
            case KeyCode.A:
            case KeyCode.LeftArrow:
                ForegroundImage.sprite = LeftImage;
                break;
            case KeyCode.S:
            case KeyCode.DownArrow:
                ForegroundImage.sprite = DownImage;
                break;
            case KeyCode.D:
            case KeyCode.RightArrow:
                ForegroundImage.sprite = RightImage;
                break;

        }
    }

    public void SetStatus(LetterStatus s)
    {
        Status = s;
        if (s == LetterStatus.Success)
        {
            BackgroundImage.color = Color.green;
        }
        else if (s == LetterStatus.Fail)
        {
            BackgroundImage.color = Color.red;
        }
        else
        {
            BackgroundImage.color = Color.clear;
        }

    }
}
