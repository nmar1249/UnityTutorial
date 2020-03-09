using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxSpeed = 3.0f;
    public float changeTime = 3.0f;

    public bool broken;
    public int maxHealth = 1;
    public int maxRange = 5; //max wandering range of 5 units

    public bool vertical;

    int curRange;
    int currentHealth;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        broken = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if robot is fixed, return
        if(!broken)
        {
            return;
        }

        timer -= Time.deltaTime;

        if(timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
            position.x = position.x + Time.deltaTime * maxSpeed * direction;
        }
        else
        {
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + Time.deltaTime * maxSpeed * direction;
        }

        rigidbody2D.MovePosition(position);
    }

    //check for collision with PC
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if(player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false; //cant stop projectiles or hurt PC
    }
}
