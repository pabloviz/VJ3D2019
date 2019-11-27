using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float velZ;
    public float angle;
    public GameObject ball;
    Ball ballScript;
    public bool shake;
    public float shakeFrames, shakeTime, shakeSeverity, time;
    Vector3 camPosAux;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        Vector3 posBall = ball.transform.position;
        gameObject.transform.position = new Vector3(posBall.x, posBall.y+5, posBall.z-5);
        gameObject.transform.rotation = Quaternion.Euler(angle, 0, 0);
        ballScript = ball.GetComponent<Ball>();
        shakeFrames = 0.3f;
        shake = false;
        shakeSeverity = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        shakeTime += Time.deltaTime;
        //follow player if it's not dead
        Vector3 posBall = ball.transform.position;
        Vector3 posCamera = gameObject.transform.position;
        if (ballScript.dead != true)
            gameObject.transform.position = new Vector3(posCamera.x, posCamera.y, posBall.z-5);

        //shake
        if (shake && shakeTime <= shakeFrames)
            gameObject.transform.position = gameObject.transform.position + Random.insideUnitSphere * shakeSeverity;
        else if (shake)
        {
            //restore cam position and shake boolean
            shake = false;
            gameObject.transform.position = new Vector3(camPosAux.x, camPosAux.y, posBall.z - 5);
        }
       
    }

    public void setShake()
    {
        shake = true;
        shakeTime = 0;
        camPosAux = gameObject.transform.position;
    }
}
