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
                transform.forward = transform.position - GravityField.Instance.transform.position;
                transform.position = rose.transform.position;
                transform.parent = rose.transform;
                holder.RemoveCurrentItem();
                break;
            }
        }
    }
    
    public virtual void Grabed()
    {
        base.Grabed();
        
        transform.localPosition = new Vector3(0.55f,-0.46f,0.23f);
        transform.localEulerAngles = new Vector3(-170.45f,175.275f,177.45f);

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
