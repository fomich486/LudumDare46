using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New gamedisgne data", menuName = "Game designe data", order = 51)]
public class GameDesigneData : ScriptableObject
{
    [Header("Shadow damage")]
    public float sh_Damage = 5f;
    public float sh_delay = 1f;

    public float wc_heal = 30f;
    public float wc_delay = 20f;
}


