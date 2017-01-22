using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{

    public Transform Root;

    public Image CountdownText;
    public GameObject WheelParent;
    public Image BuKimeGirsinText;
    public GameObject WaveObject;
    public GameObject WheelArrow;
    public GameObject PlayerOneBonusSequence;
    public Text PlayerOneBonusSequenceText;
    public GameObject PlayerTwoBonusSequence;
    public Text PlayerTwoBonusSequenceText;

    public bool isSafeMode = false;

    [Header("Anim curves")]
    public AnimationCurve CountdownTextSizeCurve;
    public AnimationCurve WheelSpeedCurve;
    public AnimationCurve SelectedItemFocusCurve;
    public AnimationCurve BuKimeGirsinTextFocusCurve;
    public AnimationCurve BuKimeGirsinTextDefocusCurve;
    public AnimationCurve SelectedItemDefocusCurve;
    public AnimationCurve HasirtCurve;
    public AnimationCurve GirisGeriAlmaCurve;
    public AnimationCurve GirisCurve;

    [Header("Game over things")]
    public Transform HasirtText;
    public GameObject GameOverPanel;
    public Text WinnerText;
    public GameObject PressSpaceText;
    public Image sagdakineGirdiImage;
    public Image soldakineGirdiImage;
    public Image pressSpaceImage;

    [Header("Avatar Reactions")]
    public Image Player1Avatar;
    public Image Player2Avatar;
    public Sprite[] Player1Reactions = new Sprite[3];
    public Sprite[] Player2Reactions = new Sprite[3];

    [Header("CountDown Images")]
    public Sprite[] countdownSprites = new Sprite[4];

        
    private bool _isWaitingForResetKey;

    public void GameOver(bool isPlayerOneWinner)
    {
        GameOverPanel.SetActive(true);
        WinnerText.text = isPlayerOneWinner ? "SAĞDAKİNE GIRDI" : "SOLDAKİNE GIRDI";
        if(isSafeMode)
        {
            WinnerText.text = isPlayerOneWinner ? "SOLDAKİ KAZANDI" : "SAĞDAKİ KAZANDI";
        }
        if(isPlayerOneWinner)
        {
            sagdakineGirdiImage.gameObject.SetActive(true);
            soldakineGirdiImage.gameObject.SetActive(false);
        }
        else
        {
            sagdakineGirdiImage.gameObject.SetActive(false);
            soldakineGirdiImage.gameObject.SetActive(true);
        }
        StartCoroutine(MoveHasirt());
        StartCoroutine(WaitAndEnableRestart());
    }

    public void UpdateAvatarReactions(float wavePercentage)
    {
        if(wavePercentage < 0.2f)
        {
            Player1Avatar.sprite = Player1Reactions[0];
            Player2Avatar.sprite = Player2Reactions[2];
        }
        else if(wavePercentage < 0.4f)
        {
            Player1Avatar.sprite = Player1Reactions[1];
            Player2Avatar.sprite = Player2Reactions[2];
        }
        else if(wavePercentage < 0.6f)
        {
            Player1Avatar.sprite = Player1Reactions[2];
            Player2Avatar.sprite = Player2Reactions[2];
        }
        else if(wavePercentage < 0.8f)
        {
            Player1Avatar.sprite = Player1Reactions[2];
            Player2Avatar.sprite = Player2Reactions[1];
        }
        else
        {
            Player1Avatar.sprite = Player1Reactions[2];
            Player2Avatar.sprite = Player2Reactions[0];
        }
    }

    IEnumerator MoveHasirt()
    {
        var initScale = Vector3.one * 0.001f;
        var targetScale = HasirtText.localScale;

        for (var t = 0f; t < 1f; t += Time.deltaTime)
        {
            HasirtText.localScale = Vector3.LerpUnclamped(initScale, targetScale, HasirtCurve.Evaluate(t));
            yield return null;
        }

        //var initPos = HasirtText.position;
        //var targetPos = new Vector2(Screen.width / 2f, initPos.y);
        //for (var t = 0f; t < 1f; t += Time.deltaTime)
        //{
        //    HasirtText.position = Vector2.Lerp(initPos, targetPos, HasirtCurve.Evaluate(t));
        //    yield return null;
        //}

    }

    IEnumerator WaitAndEnableRestart()
    {
        yield return new WaitForSeconds(2f);
        PressSpaceText.SetActive(true);
        _isWaitingForResetKey = true;
    }

    void Update()
    {
        if (_isWaitingForResetKey)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
}
