using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public float velZ, maxDistanceFromPlayer;
    public bool win;
    public GameObject player;
    Ball playerScript;
    public Vector3 initialPos;
    
    // Start is called before the first frame update
    void Start()
    {
        velZ = 0.07f;
        maxDistanceFromPlayer = 10.0f;
        initialPos = gameObject.transform.position;
        playerScript = player.GetComponent<Ball>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z - maxDistanceFromPlayer > gameObject.transform.position.z + velZ)
        {
            gameObject.transform.position = new Vector3 (initialPos.x, initialPos.y, player.transform.position.z - maxDistanceFromPlayer);
        }
        else
        {
            if (!win) gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0, velZ);
        }

    }

    public void winPlane()
    {
        win = true;
    }

}
