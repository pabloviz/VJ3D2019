using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    public float speed;
    public float time;
    public float th;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float zpos = transform.position.z;
        float playerzpos = player.transform.position.z;
        float dist = zpos-playerzpos;
        if (dist < th){
            gameObject.transform.Translate(0,0,speed*0.2f);
        }
        /*
        time += (Time.deltaTime)/speed;
        if ((int)(time % 2) == 0)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0.1f, 0, 0);
        }
        else
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(-0.1f, 0, 0);
        }
        */
    }
}
