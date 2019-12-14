using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    // Start is called before the first frame update
    public bool left;
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		if (left) GetComponent<Rigidbody>().AddForce(0, 15.0f, 0, ForceMode.Force);
        else GetComponent<Rigidbody>().AddForce(0, 15.0f, 0, ForceMode.Force);
    }
}
