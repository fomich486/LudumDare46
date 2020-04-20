using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaobabHealth : Health
{
    public ParticleSystem destroyParticle;
    public override void AditionalEffect()
    {
        Debug.Log("Baobab health:" + currentHealth);
    }

    public override void Die()
    {
        //TODO: Spawn player heal with 10% chance
        GameController.Instance.BaobabsCount--;
        Destroy(Instantiate(destroyParticle, transform.position, Quaternion.identity), destroyParticle.main.duration);
        Destroy(gameObject);
    }
}
