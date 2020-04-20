using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected Rigidbody rb;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public virtual void Use(ItemHolder holder)
    {
        
    }

    public virtual void Grabed()
    {
        rb.isKinematic = true;
    }

    public virtual void Throwed(Vector3 direction)
    {
        rb.isKinematic = false;
        transform.parent = null;
        AudioManager.PlaySound(AudioManager.Instance.audioData.throwItem);
        rb.AddForce(direction * 0.25f,ForceMode.Impulse);
    }
}
