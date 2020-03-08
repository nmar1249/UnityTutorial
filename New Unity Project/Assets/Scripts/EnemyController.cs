using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxSpeed = 3.0f;
    public float changeTime = 3.0f;

    public int maxHealth = 1;
    public int maxRange = 5; //max wandering range of 5 units

    public bool vertical;

    int curRange;
    int currentHealth;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.x = position.x + Time.deltaTime * maxSpeed * direction;
        }
        else
        {
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
}
