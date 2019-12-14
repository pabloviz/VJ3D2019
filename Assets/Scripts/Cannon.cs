using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonBall;
    public float time;
    public bool left;
    // Start is called before the first frame update
    void Start()
    {
        time = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.6f)
        {
            GameObject cb = cannonBall;
            CannonBall cbScript = cb.GetComponent<CannonBall>();
            cbScript.left = left;
            time = 0;
            GameObject g = Instantiate(cb);
            g.transform.position = gameObject.transform.position;
			if (left) g.GetComponent<Rigidbody>().AddForce(-20.0f,3.0f,0.0f,ForceMode.Impulse);
            else g.GetComponent<Rigidbody>().AddForce(20.0f, 3.0f, 0.0f, ForceMode.Impulse);
            Destroy(g,5);
        }
    }
}
