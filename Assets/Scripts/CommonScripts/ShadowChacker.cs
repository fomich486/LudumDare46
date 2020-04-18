using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowChacker : MonoBehaviour
{
    public Transform lightPoint;
    public LayerMask layers;
    
    public bool CheckShadow()
    {
        RaycastHit raycastHit;
        Ray ray = new Ray(transform.position, lightPoint.position - transform.position);
        return Physics.Raycast(ray, out raycastHit, layers);
//        Debug.DrawRay(ray.origin,ray.direction,Color.yellow,Time.deltaTime);
//        Physics.Raycast(ray, out raycastHit,10, layers);
//        Debug.Log("Hited object name is " + raycastHit.collider.name);
    }
}
