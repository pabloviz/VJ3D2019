using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour
{
    public bool open;
    public float angle, step, speed;
    Collider col;

    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        col = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (open && angle < 90)
        {
            /* ROTATION
            step = (Time.deltaTime) * speed; //how much distance to cover
            angle += step;
            gameObject.transform.rotation = Quaternion.Euler(-angle, 0, 0);
            */
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, -speed, 0);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        open = true;
    }
}
