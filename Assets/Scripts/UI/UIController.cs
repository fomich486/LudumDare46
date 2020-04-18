using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    public Image PlayerHealth;

    public static void ChangePlayerHealth(float value)
    {
        Instance.PlayerHealth.fillAmount = value;
    }
}
