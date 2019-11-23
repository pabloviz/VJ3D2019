using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float speed;
    public float time;
    public float step;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        step = (Time.deltaTime) / speed; //how much distance to cover
        time += step;
        
        //rise
        if (time < 1)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, step, 0);
        }

        //down
        else if (time > 3 && time < 4)
        {
            gameObject.transform.position = gameObject.transform.position - new Vector3(0, step, 0);
        }

        //reset cycle
        else if (time > 5) time = 0;
    }
}
