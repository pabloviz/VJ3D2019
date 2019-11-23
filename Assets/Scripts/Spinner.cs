using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float speed;
    public float time;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += (Time.deltaTime)*speed;
        angle = time;
        gameObject.transform.rotation = Quaternion.Euler(0, angle, 0);

    }
}
