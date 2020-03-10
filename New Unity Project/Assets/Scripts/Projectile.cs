using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ParticleSystem hitEffect;
    Rigidbody2D rigidbody2d;
    // Awake is called on instantiation
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //destroy projectile if farther than 1000 units from origin
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    //called on launch
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    //called on collision
    void OnCollisionEnter2D(Collision2D other)
    {
        //boom boom effect
        ParticleSystem HitEffect = Instantiate(hitEffect, rigidbody2d.position, Quaternion.identity);
        EnemyController e = other.collider.GetComponent<EnemyController>();

        //fix if not null
        if(e != null)
        {
            e.Fix();
            try
            {
                Debug.Log("attempting to play sprite anim");
                
            }
            catch(System.Exception ex)
            {
                Debug.Log("can't play sprite animation");
            }
       
        }

        HitEffect.GetComponent<ParticleSystem>().Play(); //play particle effect
        //destroy projectile upon valid collision
        Destroy(gameObject);
    }
}
