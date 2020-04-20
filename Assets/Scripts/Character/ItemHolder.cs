using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Z - throw/grab item
// X - use item

public class ItemHolder : MonoBehaviour
{
    public float grabRadius;
    public Sprite NoItem;
    private Item currentItem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeHolderHandState();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            UseItem();
        }
        else
        {
            if (currentItem == null)
            {
                UIController.Instance.CurrentItem.sprite = NoItem;
                Debug.Log("Current item is null");
            }
            else
            {
                UIController.Instance.CurrentItem.sprite = currentItem.SpriteItem;
            }
        }
    }

    private void UseItem()
    {
        if (currentItem != null)
            currentItem.Use(this);
    }

    private void ChangeHolderHandState()
    {
        if (currentItem == null)
        {
            Vector3 center = transform.parent.position;
            //Debug.DrawLine(center,center + transform.forward * grabRadius,Color.green,0.5f);
            Collider[] hitColliders = Physics.OverlapSphere(center, grabRadius);
           
            foreach (var collider in hitColliders)
            {
                DomeItem item = collider.GetComponent<DomeItem>();
                if (item != null)
                {
                    currentItem = item;
                    UIController.Instance.CurrentItem.sprite = item.SpriteItem;
                    currentItem.transform.parent = transform;
                    currentItem.transform.localPosition = Vector3.zero;
                    AudioManager.PlaySound(AudioManager.Instance.audioData.pickUp);
                    item.Grabed();
                    return;
                }
            }
            
            foreach (var collider in hitColliders)
            {
                Item item = collider.GetComponent<Item>();
                if (item != null)
                {
                    currentItem = item;
                    currentItem.transform.parent = transform;
                    currentItem.transform.localPosition = Vector3.zero;
                    AudioManager.PlaySound(AudioManager.Instance.audioData.pickUp);
                    item.Grabed();
                    break;
                }
            }
        }
        else
        {
            //current item remove from hand
            
            currentItem.Throwed(transform.forward);
            RemoveCurrentItem();
        }
    }

    public void RemoveCurrentItem()
    {
        currentItem = null;
    }
}
