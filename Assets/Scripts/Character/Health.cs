﻿using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealth = 100f;
    protected float currentHealth;
    public float CurrentHealth {
        get { return currentHealth; }
        set
        {
            if (value > maxHealth)
                currentHealth = maxHealth;
            else
                currentHealth = value;

            AditionalEffect();

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
        }
            
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void AditionalEffect()
    {
        float normalizedValue = currentHealth / maxHealth;
        UIController.ChangePlayerHealth(normalizedValue);
    }

    public virtual void Die()
    {
        UIController.Instance.GameOver("Your hero is out of health.");
    }
}
