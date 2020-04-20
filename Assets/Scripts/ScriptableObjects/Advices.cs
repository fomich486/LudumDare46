using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Advice data", menuName = "Advice data", order = 51)]
public class Advices : ScriptableObject
{
    public List<string> advices = new List<string>();

    public string GetRandomAdvice()
    {
        int rand = Random.Range(0, advices.Count);
        return advices[rand];
    }
}
