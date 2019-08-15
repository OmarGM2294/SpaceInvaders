using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public int life;
    public Sprite leftWasted;
    public Sprite rightWasted;
    // Start is called before the first frame update
    void Start()
    {
        life = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (life == 0)
        {
            Destroy(gameObject);
        }
        if (life == 5)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = leftWasted;
            transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = rightWasted;
            transform.GetChild(1).transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
