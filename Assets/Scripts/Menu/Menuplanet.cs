using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menuplanet : MonoBehaviour
{
    public float angles;
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position,Vector3.up,angles*Time.deltaTime);
    }
}
