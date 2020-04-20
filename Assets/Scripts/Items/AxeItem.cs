using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeItem : Item
{
    public override void Use(ItemHolder holder)
    {
        Vector3 center = holder.transform.parent.position;

        //Debug.DrawLine(center,center + transform.forward * grabRadius,Color.green,0.5f);
        Collider[] hitColliders = Physics.OverlapSphere(center, holder.grabRadius);
        foreach (var collider in hitColliders)
        {
            BaobabHealth baobab = collider.GetComponent<BaobabHealth>();
            if (baobab != null)
            {
                AudioManager.PlaySound(AudioManager.Instance.audioData.chop);
                baobab.CurrentHealth -= GameController.Instance.GameDesigneData.axe_damage;
                break;
            }
        }
    }

    public override void Grabed()
    {
        base.Grabed();
        transform.localEulerAngles = new Vector3(-90f,0,90f);
    }
}
