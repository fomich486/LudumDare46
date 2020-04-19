using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public bool isWindActive = true;
    private RoseHealth rose;
    private float nextUpdateTime;

    private void Start()
    {
        rose = FindObjectOfType<RoseHealth>();
    }

    void Update()
    {
        if (isWindActive)
        {
            if (Time.time > nextUpdateTime)
            {
                rose.CheckWindDamage();
                nextUpdateTime = Time.time + GameController.Instance.GameDesigneData.wind_delay;
            }
        }
    }
}
