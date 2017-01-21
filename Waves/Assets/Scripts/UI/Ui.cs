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

    public Text CountdownText;
    public GameObject WheelParent;
    public Text BuKimeGirsinText;
    public GameObject WaveObject;
    public GameObject WheelArrow;
    public GameObject PlayerOneBonusSequence;
    public Text PlayerOneBonusSequenceText;
    public GameObject PlayerTwoBonusSequence;
    public Text PlayerTwoBonusSequenceText;

    public bool isSafeMode = false;

    [Header("Game over things")]
    public Transform HasirtText;
    public GameObject GameOverPanel;
    public Text WinnerText;
    public GameObject PressSpaceText;

    private bool _isWaitingForResetKey;

    public void GameOver(bool isPlayerOneWinner)
    {
        GameOverPanel.SetActive(true);
        WinnerText.text = isPlayerOneWinner ? "SAĞDAKİNE GIRDI" : "SOLDAKİNE GIRDI";
        if(isSafeMode)
        {
            WinnerText.text = isPlayerOneWinner ? "SOLDAKİ KAZANDI" : "SAĞDAKİ KAZANDI";
        }
        StartCoroutine(WaitAndEnableRestart());
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
