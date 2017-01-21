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
    public Sprite JokerImage;

    void Awake()
    {

    }

    void Start()
    {
        Status = LetterStatus.TBD;
        BackgroundImage.color = Color.clear;

        if(isJoker)
        {
            ForegroundImage.sprite = JokerImage;
        }
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
            StartCoroutine(SuccessEffect());
        }
        else if (s == LetterStatus.Fail)
        {
            BackgroundImage.color = Color.red;
            StartCoroutine(FailEffect());
        }
        else
        {
            BackgroundImage.color = Color.clear;
        }
    }

    IEnumerator SuccessEffect()
    {
        const float effectTime = 0.1f;

        var initScale = transform.localScale * 1.4f;
        var targetScale = transform.localScale;

        var c = AnimationCurve.EaseInOut(0, 0, 1, 1);

        for (var t = 0f; t < 1f; t += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(initScale, targetScale, c.Evaluate(t / effectTime));
            yield return null;
        }
    }

    IEnumerator FailEffect()
    {
        var initScale = transform.localScale;
        transform.localScale *= 1.6f;
        transform.Rotate(Vector3.forward, -30);
        yield return new WaitForSeconds(0.5f);
        transform.rotation = Quaternion.identity;
        transform.localScale = initScale;
    }
}
