using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		GetComponent<Rigidbody>().AddForce(0,15.0f,0,ForceMode.Force);
    }
}
