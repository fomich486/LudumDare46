using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCanItem : Item
{
    public override void Use(ItemHolder holder)
    {
        Vector3 center = holder.transform.parent.position;
        //Debug.DrawLine(center,center + transform.forward * grabRadius,Color.green,0.5f);
        Collider[] hitColliders = Physics.OverlapSphere(center, holder.grabRadius);
        foreach (var collider in hitColliders)
        {
            RoseHealth rose = collider.GetComponent<RoseHealth>();
            if (rose != null)
            {
                rose.HealRose();
                break;
            }
        }
    }

    public override void Grabed()
    {
        base.Grabed();
        transform.localPosition = new Vector3(0.12f,-0.32f,0.02f);
        transform.localEulerAngles = new Vector3(-184.73f,-4.4f,-197.25f);
    }
}
