using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float velZ, sideVel, jumpVel;
    float velY, velX, deathVel;
    Rigidbody rb;
    public bool grounded, dead;
    private Animation anim;
    public float animationSpeed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        velY = 0;
        velX = 0;
        deathVel = 0.1f;
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animation>();
        anim["Correr"].speed = animationSpeed;
        grounded = false;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            //check for player input
            if (Input.GetKey("left"))
            {
                velX = -sideVel;
            }
            else if (Input.GetKey("right"))
            {
                velX = sideVel;
            }
            else velX = 0f;

            //check for jump
            //You can only jump if you are grounded:

            if (Input.GetKeyDown("space") && grounded)
            {
                rb.AddForce(0, jumpVel, 0, ForceMode.Impulse);
            }

            gameObject.transform.position = gameObject.transform.position + new Vector3(velX, velY, velZ);
        }

        else
        {
            if (gameObject.transform.localScale.x > 0)
                gameObject.transform.localScale = gameObject.transform.localScale - new Vector3(deathVel, deathVel, deathVel);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ground")
        {
            grounded = true;
        }

        if (other.tag == "death")
        {
            dead = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ground")
        {
            grounded = false;
        }
    }
}
