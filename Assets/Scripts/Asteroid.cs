using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    public ParticleSystem destroyParticle;
    private float StartImpuls = 1f;
    private Rigidbody rb;
    public void Init()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = Random.onUnitSphere * 10f + GravityField.Instance.transform.position;
        Vector3 direction = (GravityField.Instance.transform.position - transform.position).normalized;
        rb.AddForce(direction * StartImpuls,ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.GetComponent<Health>())
        {
            Debug.Log("Something with health was hited");
            
            other.collider.GetComponent<BaobabHealth>()?.Die();
            
            if (other.collider.GetComponent<CharacterController>() != null)
            {
                UIController.Instance.GameOver("Asteroid destroyed your hero.");
            }
            
            if (other.collider.GetComponent<RoseHealth>() != null)
            {
                UIController.Instance.GameOver("Asteroid destroyed rose.");
            }

            Die();
        }
        else
        {
            Die();    
        }
    }

    private void Die()
    {
        AudioManager.PlaySound(AudioManager.Instance.audioData.explosion);
        Destroy(Instantiate(destroyParticle, transform.position, Quaternion.identity), destroyParticle.main.duration);
        Destroy(gameObject);
    }
}
