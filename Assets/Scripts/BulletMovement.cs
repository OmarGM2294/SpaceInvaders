using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 move = new Vector2(transform.position.x, transform.position.y + speed);
        transform.position = move;

        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}
