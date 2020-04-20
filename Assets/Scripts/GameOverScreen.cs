using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI txt_loseReason;
    public TextMeshProUGUI txt_timeInGame;

    public void Init(string reason, string time)
    {
        txt_loseReason.text = reason;
        txt_timeInGame.text = "You held out " + time + " seconds";
    }
}
