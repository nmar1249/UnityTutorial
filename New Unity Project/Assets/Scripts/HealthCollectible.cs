using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public ParticleSystem PickupEffect;
    //trigger on collision
    void OnTriggerEnter2D(Collider2D other)
    { 
        RubyController controller = other.GetComponent<RubyController>();
        ParticleSystem effect = Instantiate(PickupEffect, other.attachedRigidbody.position, Quaternion.identity);
       
        if (controller != null)
        {
            controller.ChangeHealth(1);
            effect.GetComponent<ParticleSystem>().Play(); //play effect
            Destroy(gameObject);
        }

    }
}
