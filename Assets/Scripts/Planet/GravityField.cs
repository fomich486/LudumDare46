using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityField : Singleton<GravityField>
{
    private float gravityForce = 0.25f;

    private float nextUpdateTime = 0;

    private float delay = 0.02f;
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextUpdateTime)
        {
            ApplyPlanetGravity();
            nextUpdateTime = nextUpdateTime + delay;
        }
    }

    private void ApplyPlanetGravity()
    {
        Vector3 center = transform.position;
        float radius = 20;
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        foreach (var collider in hitColliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if(rb == null)
                continue;

            Vector3 direction = transform.position - collider.transform.position;
            
            rb.AddForce(gravityForce * direction);
        }
    }
}
