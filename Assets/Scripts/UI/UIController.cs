using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : Singleton<UIController>
{
    public Advices Advices;
    public Image PlayerHealth;
    public Image RoseHealth;
    public TextMeshProUGUI txt_bobabAmount;
    public TextMeshProUGUI txt_stateAdvice;
    public TextMeshProUGUI txt_timeInGame;
    public GameOverScreen gameoverScreen;
    public Image CurrentItem;
    public static void ChangePlayerHealth(float value)
    {
        Instance.PlayerHealth.fillAmount = value;
    }  
    public static void ChangeRoseHealth(float value)
    {
        Instance.RoseHealth.fillAmount = value;
    }

    public static void ChangeStateAdvice(string advice)
    {
        Instance.txt_stateAdvice.text = "ADVICE: " + advice;
    }

    private void Update()
    {
        txt_bobabAmount.text =  GameController.Instance.BaobabsCount.ToString();
        txt_timeInGame.text = (Mathf.Round(Time.time * 100f) / 100f).ToString();
    }

    public void GameOver(string reason)
    {
        if (!GameController.Instance.isGameover)
        {
            GameController.Instance.isGameover = true;
            gameoverScreen.gameObject.SetActive(true);
            string currentTime = (Mathf.Round(Time.time * 100f) / 100f).ToString();
            gameoverScreen.Init(reason ,currentTime);
        }
    }
}
