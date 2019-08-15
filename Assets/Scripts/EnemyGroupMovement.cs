using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupMovement : MonoBehaviour
{
    private int initialDirection = 0;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        while(initialDirection == 0)
        {
            initialDirection = Random.Range(-1, 1);
        }
        InvokeRepeating("Move", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {
        if (transform.position.x >= 12 || transform.position.x <= -12)
        {
            initialDirection *= -1;
        }
        Vector2 move = new Vector2(transform.position.x + initialDirection, transform.position.y - speed);
        transform.position = move;
    }
}
