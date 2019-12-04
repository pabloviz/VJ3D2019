using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    public float speed;
    public float time;
    public float th;
    public GameObject player;
	private Animation anim;
	private Transform rod;
	private float totaldist;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        player = GameObject.Find("Player");
		anim = GetComponentInChildren<Animation>();
		rod = transform.GetChild(0);
		totaldist = rod.GetComponent<BoxCollider>().bounds.size.x;
		totaldist -= totaldist/6;
		anim["girar"].speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float zpos = transform.position.z;
        float playerzpos = player.transform.position.z;
        float dist = zpos-playerzpos;
        if (dist < th){
			if(totaldist > 0){
				rod.Translate(0,0,speed*0.2f);
				totaldist -= Mathf.Abs(speed)*0.2f;
				anim.Play("girar");
			}else{
				anim.Stop("girar");
			}

			
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
