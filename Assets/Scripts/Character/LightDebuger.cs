using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDebuger : MonoBehaviour
{
    public Transform LightPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position,LightPoint.position,Color.green,Time.deltaTime);
    }
}
