using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageWarnings : Singleton<DamageWarnings>
{
    public TextMeshProUGUI playerShadow;
    public TextMeshProUGUI roseShadow;
    public TextMeshProUGUI roseWind;
    public TextMeshProUGUI roseDomedNoWind;
    public TextMeshProUGUI baobabWasSpawned;

    public void ShowBaobabSpawnedInfo()
    {
        StartCoroutine(BabobabShow());
    }

    private IEnumerator BabobabShow()
    {
        baobabWasSpawned.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        baobabWasSpawned.gameObject.SetActive(false);
    }
}
