using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public RuntimeAnimatorController destroy;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag != "Enemy")
            {
                Shoot();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Bullet")
        {
            GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = ChangeScore();
            Destroy(other.gameObject);
            this.GetComponent<Animator>().runtimeAnimatorController = destroy;
        }
    }

    void EnemyHitDestroy()
    {
        Destroy(gameObject);
    }

    void Shoot()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy Bullet").Length == 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }

    string ChangeScore()
    {
        string result = "000";
        GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>().score += 10;
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
