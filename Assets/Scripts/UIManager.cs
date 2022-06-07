using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [SerializeField] private Button restartButton;
    [SerializeField] private TextMeshProUGUI message;
    [SerializeField] private Image overlay;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ShowLoseMenu()
    {
        ShowUI();
        message.text = "You Lose";
        message.color = new Color(1f, 0.5f, 0.5f);
    }

    public void ShowWinMenu()
    {
        ShowUI();
        message.text = "You Win";
        message.color = new Color(0.5f, 1f, 0.5f);
    }
    
    public void HideUI()
    {
        message.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        overlay.gameObject.SetActive(false);
    }

    private void ShowUI()
    {
        message.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        overlay.gameObject.SetActive(true);
    }
}
