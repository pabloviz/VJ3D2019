using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingSaw : MonoBehaviour
{
    public float angle, speed, time;
    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += (Time.deltaTime) * speed;
        // Saw moves back and forth
        angle = Mathf.Sin(time)*90; //sin = [-1, 1], our angle is [-90, 90]
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
