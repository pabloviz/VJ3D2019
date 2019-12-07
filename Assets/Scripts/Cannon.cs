using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonBall;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 2)
        {
            GameObject cb = cannonBall;
            time = 0;
            Instantiate(cb);
            cb.transform.position = gameObject.transform.position;
        }
    }
}
