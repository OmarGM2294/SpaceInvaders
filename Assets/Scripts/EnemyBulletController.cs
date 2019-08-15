using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Rotate", 0.2f, 0.2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 move = new Vector2(transform.position.x, transform.position.y - speed);
        transform.position = move;

        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }

    void Rotate()
    {
        if (transform.rotation.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else if (transform.rotation.y == -1.0f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Shield")
        {
            other.GetComponent<ShieldController>().life -= 1;
            Destroy(gameObject);
        }
    }
}
