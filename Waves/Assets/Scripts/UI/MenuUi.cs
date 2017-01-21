using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUi : MonoBehaviour
{
    public Button PlayButton;

    void Start()
    {
        PlayButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game");
        });
    }
}
