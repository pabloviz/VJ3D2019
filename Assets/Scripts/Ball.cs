using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float velMod, jumpVel;
    private float velX, velY, velZ;
    private Vector3 vel;
    float deathVel;
    Rigidbody rb;
    public bool grounded, dead;
    private Animation anim;
    string currentAnimation = "";
    public Transform body;

    private float sincos45 = Mathf.Sqrt(2)/2.0f;
    // Start is called before the first frame update
    void Start()
    {
        velY = 0.0f;
        velX = 0.0f;
        velZ = velMod;
        deathVel = 0.1f;
        rb = gameObject.GetComponent<Rigidbody>();

        anim = body.gameObject.GetComponent<Animation>();  
        anim["Correr_F"].speed = 30*velZ;
        anim["Correr_L"].speed = 30*velZ;
        anim["Correr_R"].speed = 30*velZ;
        anim["Saltar"].speed = 40*velZ;
        ChangeAnim("Correr_F");

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
                velX = -sincos45*velMod;
                velZ = sincos45*velMod;
                if(grounded)ChangeAnim("Correr_L");
                else ChangeAnim("Saltar_L");

            }
            else if (Input.GetKey("right"))
            {
                velX = sincos45*velMod;
                velZ = sincos45*velMod;
                if(grounded)ChangeAnim("Correr_R");
                else ChangeAnim("Saltar_R");
            }
            else {
                velX = 0f;
                velZ = velMod;
                if(grounded)ChangeAnim("Correr_F");
                else ChangeAnim("Saltar_F");
            }

            //check for jump
            //You can only jump if you are grounded:

            if (Input.GetKeyDown("space") && grounded)
            {
                rb.AddForce(0, jumpVel, 0, ForceMode.Impulse);
                ChangeAnim("Saltar");
                grounded = false;
            }

            //gameObject.transform.position = gameObject.transform.position + new Vector3(velX, velY, velZ);
            transform.Translate(velX,velY,velZ);
        }

        else
        {
            if (gameObject.transform.localScale.x > 0)
                gameObject.transform.localScale = gameObject.transform.localScale - new Vector3(deathVel, deathVel, deathVel);
        }
    }

    private void ChangeAnim(string a){
        if (a != currentAnimation) anim.Play(a);
        currentAnimation = a;

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
/*
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ground")
        {
            grounded = false;
        }
    }
*/
}
