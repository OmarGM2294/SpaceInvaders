using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipController : MonoBehaviour
{
    public float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2(transform.position.x - speed, transform.position.y);
        transform.position = move;

        if (transform.position.x <= -24)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Bullet")
        {
            GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = ChangeScore();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    string ChangeScore()
    {
        string result = "000";
        GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>().score += 100;
        int score = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>().score;
        if (score <= 9)
        {
            result = "00" + score.ToString();
        } else if (score >= 10 && score <= 99)
        {
            result = "0" + score.ToString();
        } else if (score >= 100)
        {
            result = score.ToString();
        }
        return result;
    }
}
