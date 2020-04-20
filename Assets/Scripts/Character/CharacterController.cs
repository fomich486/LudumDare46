using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("References")]
    public Health health;
    public Movement movement;
    public ShadowChacker shadowChacker;
    //TODO: Add grabers interaction here

    private float nextApplydamageTime = 0;

    private void Update()
    {
        if (shadowChacker.CheckShadow())
        {
            DamageWarnings.Instance.playerShadow.gameObject.SetActive(true);
            if (nextApplydamageTime < Time.time)
            {
                health.CurrentHealth -= GameController.Instance.GameDesigneData.sh_Damage;
                nextApplydamageTime = Time.time + GameController.Instance.GameDesigneData.sh_delay;
            }
        }
        else
        {
            DamageWarnings.Instance.playerShadow.gameObject.SetActive(false);
        }

    }
}
