using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Item
{
    public override void Grabed()
    {
        base.Grabed();
        transform.localPosition = new Vector3(0.86f,-0.78f,0.24f);
        transform.localEulerAngles = new Vector3(-156.416f,-94.41f,-182.47f);
    }
}
