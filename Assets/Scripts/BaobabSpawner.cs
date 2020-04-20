using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaobabSpawner : MonoBehaviour
{
    public BaobabHealth BaobabPrefab;
    private CharacterController player;

    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Time.time + GameController.Instance.GameDesigneData.baobab_delay;
        player = FindObjectOfType<CharacterController>();
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        if (Time.time > nextSpawnTime)
        {
            BaobabHealth newBaobab = Instantiate(BaobabPrefab);
            newBaobab.transform.parent = GravityField.Instance.transform;
            newBaobab.transform.localPosition = -player.transform.localPosition;
            newBaobab.transform.up = newBaobab.transform.position - GravityField.Instance.transform.position;
            newBaobab.transform.localPosition -= newBaobab.transform.up * 0.01f;
            newBaobab.transform.localScale = Vector3.one * 0.101f;
            
            DamageWarnings.Instance.ShowBaobabSpawnedInfo();
            
            nextSpawnTime = Time.time + GameController.Instance.GameDesigneData.baobab_delay;
            GameController.Instance.BaobabsCount++;
        }
    }
}
