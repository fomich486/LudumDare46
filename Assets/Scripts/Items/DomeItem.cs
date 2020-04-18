using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomeItem : Item
{
    // Start is called before the first frame update
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
                rose.GetComponent<Rigidbody>().isKinematic = true;
                rb.isKinematic = true;
                
                rose.DomeRose(true);
                transform.position = rose.transform.position;
                transform.parent = rose.transform;
                holder.RemoveCurrentItem();
                break;
            }
        }
    }
    
    public virtual void Grabed()
    {
        rb.isKinematic = true;

        ItemHolder holder = transform.parent.GetComponent<ItemHolder>();
        Vector3 center = holder.transform.parent.position;

        //Debug.DrawLine(center,center + transform.forward * grabRadius,Color.green,0.5f);
        Collider[] hitColliders = Physics.OverlapSphere(center, holder.grabRadius);
        foreach (var collider in hitColliders)
        {
            RoseHealth rose = collider.GetComponent<RoseHealth>();
            if (rose != null)
            {
                rose.DomeRose(false);
                break;
            }
        }
    }
}
