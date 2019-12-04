using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float velZ;
    public float angle;
    public GameObject ball;
    Ball ballScript;
    public bool shake, win;
    public float shakeFrames, shakeTime, shakeSeverity, time, timewin, endpos;
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

        win = false;
        endpos = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        shakeTime += Time.deltaTime;
        //follow player if it's not dead
        Vector3 posBall = ball.transform.position;
        Vector3 posCamera = gameObject.transform.position;
        if (ballScript.dead != true && win != true)
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

        if (win)
        {
            float endposaux;
            if (endpos < 0.2f)
            {
                endpos += 0.01f;
                endposaux = endpos;
            }
            else endposaux = 0.0f;
            timewin += Time.deltaTime;
            gameObject.transform.position = new Vector3(posBall.x + Mathf.Cos(timewin)*5, posCamera.y - endposaux, posBall.z + Mathf.Sin(timewin)*5);
            gameObject.transform.rotation = Quaternion.Euler(angle-endpos*100, -((timewin*360/(2*Mathf.PI))+90), 0);
            

        }
       
    }

    public void setShake()
    {
        shake = true;
        shakeTime = 0;
        camPosAux = gameObject.transform.position;
    }

    public void winCam()
    {
        win = true;
        timewin = -(Mathf.PI / 2);
    }
}
