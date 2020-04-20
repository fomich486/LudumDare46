using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOrbiting : MonoBehaviour
{
    private float orbitingAngle = 2.25f;
    private Transform planet;

    private void Start()
    {
        planet = FindObjectOfType<GravityField>().transform;
    }

    void Update()
    {
        transform.RotateAround(planet.position,Vector3.up,orbitingAngle*Time.deltaTime);
        transform.LookAt(planet.position);   
    }
}
