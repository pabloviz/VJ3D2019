using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float velZ;
    public float angle;
    public GameObject ball;
    Ball ballScript;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 posBall = ball.transform.position;
        gameObject.transform.position = new Vector3(posBall.x, posBall.y+5, posBall.z-5);
        gameObject.transform.rotation = Quaternion.Euler(angle, 0, 0);
        ballScript = ball.GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        //follow player if it's not dead
        if (ballScript.dead != true)
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0, velZ);
    }
}
