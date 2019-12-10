using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{

    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, time*100);
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
