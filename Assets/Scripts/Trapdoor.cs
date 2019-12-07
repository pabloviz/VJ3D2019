using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour
{
    public bool open;
    public float angle, step, speed, time;
    Collider col;

    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        col = gameObject.GetComponent<BoxCollider>();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (open) time += Time.deltaTime;
        if (open && angle < 90)
        {
            /* ROTATION
            step = (Time.deltaTime) * speed; //how much distance to cover
            angle += step;
            gameObject.transform.rotation = Quaternion.Euler(-angle, 0, 0);
            */
           if (time > 0.3) gameObject.transform.position = gameObject.transform.position + new Vector3(0, -speed, 0);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        open = true;
    }
}
