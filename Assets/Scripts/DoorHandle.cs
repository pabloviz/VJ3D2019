using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    public float angle, speed, time;
    public bool rightDoor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += (Time.deltaTime) * speed;
        // door moves back and forth
        angle = (Mathf.Sin(time)+1) * 45; //sin = [0, 2], our angle is [0, 90]
        //if it's the right door, it rotates to the opposite side
        if (rightDoor) 
            gameObject.transform.rotation = Quaternion.Euler(180, -angle, 0);
        else gameObject.transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
