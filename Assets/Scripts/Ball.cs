using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float velMod, jumpVel, blinkingFrames, time, blinkingStart;
    private float velX, velY, velZ;
    private Vector3 vel;
    float deathVel;
    Rigidbody rb;
    Renderer rend;
    public bool grounded, dead, blinking;
    public int lives;
    private Animation anim;
    string currentAnimation = "";
    public Transform body;
    public GameObject demon, particles, cam;
    public GameObject[] liveImages;
    Camera camScript;

    private float sincos45 = Mathf.Sqrt(2)/2.0f;
    // Start is called before the first frame update
    void Start()
    {
        //time and velocity
        time = 0.0f;
        velY = 0.0f;
        velX = 0.0f;
        velZ = velMod;
        deathVel = 0.1f;

        //components
        rb = gameObject.GetComponent<Rigidbody>();
        rend = demon.GetComponent<Renderer>();
        anim = body.gameObject.GetComponent<Animation>();  

        //animations
        anim["Correr_F"].speed = 30*velZ;
        anim["Correr_L"].speed = 30*velZ;
        anim["Correr_R"].speed = 30*velZ;
        anim["Saltar"].speed = 40*velZ;
        ChangeAnim("Correr_F");

        //booleans
        grounded = false;
        dead = false;
        blinking = false;

        //timing
        blinkingFrames = 2;
        blinkingStart = 0;
        time = 0;

        //game objects
        particles.SetActive(false);

        //camera
        camScript = cam.GetComponent<Camera>();

        //misc
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        time += (Time.deltaTime);
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
            /* Quan el ninot es xoca contra alguna cosa, a vegades es cau i es torna boig o canvia per sempre
             * la seva trajectoria. Sempre hauria d'intentar seguir caminant endevant. Poder es podria fer
             * modificant la transform, com ho tenia abans.
             */
        }

        else
        {
            if (gameObject.transform.localScale.x > 0)
                gameObject.transform.localScale = gameObject.transform.localScale - new Vector3(deathVel, deathVel, deathVel);
        }

        //blinking
        if (blinking)
        {
            if (rend.enabled == false) rend.enabled = true;
            else rend.enabled = false;
            if (time - blinkingStart >= blinkingFrames)
            {
                rend.enabled = true;
                blinking = false;

                particles.SetActive(false);
            }
        }
    }

    private void ChangeAnim(string a){
        if (a != currentAnimation) anim.Play(a);
        currentAnimation = a;

    }

    private void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "ground")
        {
            grounded = true;
        }

        if (other.gameObject.tag == "death" && !blinking)
        {
            --lives;

            liveImages[lives].SetActive(false);

            particles.SetActive(true);

            camScript.setShake();

            if (lives <= 0) dead = true;
            else
            {
                blinking = true;
                blinkingStart = time;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "deathBound")
        {
            lives = 0;
            dead = true;
        }
    }

}
