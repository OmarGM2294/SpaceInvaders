using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject spaceship;
    private bool invoke = true;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(1.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (invoke)
        {
            InvokeRepeating("Spaceship", time, 1.0f);
            time = Random.Range(5.0f, 60.0f);
            invoke = false;
        }
    }

    void Spaceship()
    {
        CancelInvoke();
        Instantiate(spaceship, new Vector2(22, 9.3f), transform.rotation);
        invoke = true;
    }
}
