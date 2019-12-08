﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public int level;
    public bool debug = false, doubleJumpb;
    public float velMod, jumpVel, blinkingFrames, time, blinkingStart, speedUpVel, speedUpStart;
    public float speedDownStart;
    private float velX, velY, velZ;
    private Vector3 vel;
    float deathVel;
    Rigidbody rb;
    Renderer rend;
    public bool grounded, dead, blinking, win, speedUpb, speedDownb;
    public int lives;
    private Animation anim;
    string currentAnimation = "";
    public Transform body;
    public GameObject demon, particles, cam, deathPlane, speedParticles, slowParticles, winText, deathText;
    public GameObject[] liveImages;
    public GameObject doubleJumpImage;
    Camera camScript;
    DeathPlane deathPlaneScript;

    public AudioClip damage;
    public AudioClip boing;
    public AudioClip powerUp;
    public AudioClip powerDown;
    public AudioClip victory;

    AudioSource source;

	private float sincos45 = 1.0f;/*Mathf.Sqrt(2)/2.0f;*/

    // Start is called before the first frame update
    void Start()
    {
        //time and velocity
        time = 0.0f;
        velY = 0.0f;
        velX = 0.0f;
        velZ = velMod;
        deathVel = 0.1f;
        speedUpVel = 0.1f;

        //components
        rb = gameObject.GetComponent<Rigidbody>();
        rend = demon.GetComponent<Renderer>();
        anim = body.gameObject.GetComponent<Animation>();  

        //animations
        anim["Correr_F"].speed = 30*velZ;
        anim["Correr_L"].speed = 30*velZ;
        anim["Correr_R"].speed = 30*velZ;
        anim["Saltar"].speed = 40*velZ;
        anim["Saltar_F"].speed = 10*velZ;
        anim["Saltar_L"].speed = 10*velZ;
        anim["Saltar_R"].speed = 10*velZ;
        anim["Victoria_idle"].speed = 5;
        ChangeAnim("Correr_F");

        //booleans
        grounded = false;
        dead = false;
        blinking = false;
        win = false;
        speedUpb = false;
        doubleJumpb = false;

        //timing
        blinkingFrames = 2;
        blinkingStart = 0;
        time = 0;

        //game objects
        particles.SetActive(false);
        speedParticles.SetActive(false);
        slowParticles.SetActive(false);
        doubleJumpImage.SetActive(false);

        //camera
        camScript = cam.GetComponent<Camera>();

        //death plane
        deathPlaneScript = deathPlane.GetComponent<DeathPlane>();

        //audio
        source = gameObject.GetComponent<AudioSource>();


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

            if (Input.GetKeyDown("space") && (grounded || doubleJumpb))
            {
                rb.AddForce(0, jumpVel, 0, ForceMode.Impulse);
                ChangeAnim("Saltar");
                if (doubleJumpb && !grounded)
                {
                    doubleJumpb = false;
                    doubleJumpImage.SetActive(false);
                }
                grounded = false;
            }

            //gameObject.transform.position = gameObject.transform.position + new Vector3(velX, velY, velZ);
            if (!win) transform.Translate(velX,velY,velZ);
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

        //speedup powerup
        if (speedUpb)
        {
            if (time > speedUpStart+3)
            {
                speedUpb = false;
                velMod -= speedUpVel;
                speedParticles.SetActive(false);
            }
        }

        if (speedDownb)
        {
            if (time > speedDownStart + 3)
            {
                speedDownb = false;
                velMod += speedUpVel/2;
                slowParticles.SetActive(false);
            }
        }

        //already won
        if (win)
        {
            //ChangeWaitAnim("Victoria_idle");
            if (Input.GetKeyDown("space"))
            {
                if (level == 1)
                SceneManager.LoadScene("Level 2");
                if (level == 2)
                SceneManager.LoadScene("Main Menu");
            }
        }

        //already dead
        if (dead)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("Main Menu");
            }
        }
    }

    private void ChangeAnim(string a){
        if(win) a = "Victoria_idle";
        if (a != currentAnimation) anim.Play(a);
        currentAnimation = a;

    }
/*
    private void ChangeWaitAnim(string a){
        if(!anim.isPlaying){
            if (a != currentAnimation) anim.Play(a);
            currentAnimation = a;
        }

    }
*/

    //Podemos hacer que los obstáculos te dañen on collision o on trigger. Si lo hacemos on collision
    //el demonio se quedará parado por el obstáculo, yo creo que tiene más sentido si hacemos que sea
    //on trigger
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
            source.PlayOneShot(damage, 1);
        }

        if (other.gameObject.tag == "spring")
        {
            rb.AddForce(0, jumpVel * 1.2f, 0, ForceMode.Impulse);
            ChangeAnim("Saltar");
            grounded=false;
            debug = true;
            source.PlayOneShot(boing, 10);
        }

		if (other.gameObject.tag == "pusher")
		{
			Debug.Log("hola");
			int direction = 1;
			if (other.gameObject.transform.position.x>this.gameObject.transform.position.x) direction = -1;
			this.gameObject.transform.Translate(0,0.5f,0);
			rb.AddForce(direction*60,5,-2,ForceMode.Impulse);
		}
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "deathBound")
        {
            lives = 0;
            dead = true;
            deathText.SetActive(true);
        }

        if (other.tag == "win")
        {
            if(!win) ChangeAnim("Victoria");
            win = true;
            camScript.winCam();
            deathPlaneScript.winPlane();
            source.PlayOneShot(victory, 1);
            winText.SetActive(true);
        }

        if (other.tag == "death" && !blinking)
        {
            --lives;

            liveImages[lives].SetActive(false);

            particles.SetActive(true);

            camScript.setShake();

            if (lives <= 0)
            {
                dead = true;
                deathText.SetActive(true);
            }
            else
            {
                blinking = true;
                blinkingStart = time;
            }
            source.PlayOneShot(damage, 1);
        }


    }

    public void speedUp()
    {
        if (!speedUpb)
        {
            velMod += speedUpVel;
        }
        speedUpb = true;
        speedUpStart = time;
        speedParticles.SetActive(true);
        source.PlayOneShot(powerUp, 1);
    }

    public void speedDown()
    {
        if (!speedDownb)
        {
            velMod -= speedUpVel/2;
        }
        speedDownb = true;
        speedDownStart = time;
        slowParticles.SetActive(true);
        source.PlayOneShot(powerDown, 1);
    }

    public void doubleJump()
    {
        doubleJumpb = true;
        source.PlayOneShot(powerUp, 1);
        doubleJumpImage.SetActive(true);

    }

}
