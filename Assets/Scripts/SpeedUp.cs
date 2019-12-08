using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    // Start is called before the first frame update
	private float time;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		time += 3.0f*(Time.deltaTime);
		float sin = Mathf.Sin(time);
		this.transform.Translate(0,0,sin*0.006f);
		this.transform.Rotate(0,0,1.3f);
    }
}
