using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseHealth : Health
{
    private bool canBeHealed = true;
    private float nextHealtTime;

    public bool isDomed;
    private void Update()
    {
        if (Time.time > nextHealtTime)
        {
            canBeHealed = true;
        }
    }

    public override void AditionalEffect()
    {
        float normalizedValue = currentHealth / maxHealth;
        UIController.ChangeRoseHealth(normalizedValue);
    }

    public void HealRose()
    {
        if (canBeHealed)
        {
            CurrentHealth += GameController.Instance.GameDesigneData.wc_heal;
            canBeHealed = false;
            nextHealtTime = Time.time + GameController.Instance.GameDesigneData.wc_heal;
        }
        else
        {
            CurrentHealth -= GameController.Instance.GameDesigneData.wc_heal;
            canBeHealed = false;
            nextHealtTime = Time.time + GameController.Instance.GameDesigneData.wc_heal;
        }
    }

    public void DomeRose(bool state)
    {
        isDomed = state;
    }
}
