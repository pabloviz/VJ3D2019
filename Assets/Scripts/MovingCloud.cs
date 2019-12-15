using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCloud : MonoBehaviour
{
	public float angle, speed, time, width;
	private bool bounce = false;
	private float bounceval = 0.0f;
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
		gameObject.transform.Translate(0,angle*0.03f*Time.deltaTime,0);

		if(bounce){
			bounceval += 0.15f;
			gameObject.transform.Translate(0,0,-Mathf.Sin(bounceval)*90*Time.deltaTime*0.01f);
		}
		//gameObject.transform.Rotate(0,1,0);
	}

	private void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "player"){
			bounce = true;
		}
	}
}
