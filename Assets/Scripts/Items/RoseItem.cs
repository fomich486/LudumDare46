using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseItem : Item
{
    [Header("References")]
    public Health health;
    public ShadowChacker shadowChacker;
    //TODO: Add grabers interaction here

    private float nextApplydamageTime = 0;

    private void Update()
    {
        if (shadowChacker.CheckShadow())
        {
            if (nextApplydamageTime < Time.time)
            {
                health.CurrentHealth -= GameController.Instance.GameDesigneData.sh_Damage;
                nextApplydamageTime = Time.time + GameController.Instance.GameDesigneData.sh_delay;
            }
        }
    }

    public override void Use(ItemHolder holder)
    {
        transform.parent = null;
        rb.isKinematic = false;
        holder.RemoveCurrentItem();
        transform.up = transform.position - GravityField.Instance.transform.position;
    }
    
    public override void Grabed()
    {
        base.Grabed();
        transform.localEulerAngles = new Vector3(90f,0,0f);
    }
}
