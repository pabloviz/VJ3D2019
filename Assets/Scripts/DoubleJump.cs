using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        gameObject.transform.rotation = Quaternion.Euler(0, time * 50, 0);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            GameObject player = GameObject.Find("Player");
            Ball playerScript = player.GetComponent<Ball>();
            playerScript.doubleJump();
            gameObject.SetActive(false);
        }
    }
}
