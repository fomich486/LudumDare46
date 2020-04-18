using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
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
                Die();
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
        throw new System.NotImplementedException();
    }
}
