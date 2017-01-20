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

    public void SetKey(KeyCode k)
    {
        key = k;

        switch (k)
        {
            case KeyCode.W:
                ForegroundImage.sprite = UpImage;
                break;
            case KeyCode.A:
                ForegroundImage.sprite = LeftImage;
                break;
            case KeyCode.S:
                ForegroundImage.sprite = DownImage;
                break;
            case KeyCode.D:
                ForegroundImage.sprite = RightImage;
                break;

        }
    }

    public void SetStatus(LetterStatus s)
    {
        Status = s;
        UpdateImage();
    }

	void Start ()
    {
        Status = LetterStatus.TBD;
	}
	
	void Update ()
    {
		
	}

    void UpdateImage()
    {

    }
}
