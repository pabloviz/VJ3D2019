using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    public float time, speed;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        time += (Time.deltaTime) / speed;
        if ((int)(time % 2) == 0)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0.1f, 0, 0);
        }
        else
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(-0.1f, 0, 0);
        }
    }
}
