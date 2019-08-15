using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    public RuntimeAnimatorController destroy;
    public float speed = 1.0f;
    public GameObject prefab;
    public int lifes = 3;
    public int score = 0;

    private bool destroyed;
    // Start is called before the first frame update
    void Start()
    {
        destroyed = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = new Vector2 ((Input.GetAxis("Horizontal") / 10) + transform.position.x, transform.position.y);
        if (movement.x < 23 && movement.x > -23 && !destroyed)
        {
            transform.position = movement;
        }

        if (Input.GetKeyDown("space") && GameObject.FindGameObjectsWithTag("Bullet").Length == 0)
        {
            GameObject bullet = Instantiate(prefab, new Vector2(transform.position.x, -9.5f), Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy Bullet")
        {
            this.GetComponent<Animator>().runtimeAnimatorController = destroy;
            Destroy(other.gameObject);
            destroyed = true;
        }
    }

    void PlayerHit()
    {
        lifes -= 1;
        GameObject.FindGameObjectWithTag("Lifes").GetComponent<Text>().text = lifes.ToString();
        if (lifes <= 0)
        {
            Destroy(gameObject);
            print("Game Over");
        } else
        {
            this.GetComponent<Animator>().runtimeAnimatorController = null;
            destroyed = false;
        }
    }
}
