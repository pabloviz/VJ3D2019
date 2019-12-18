using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1() {
        SceneManager.LoadScene("Level 1");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("How to play");
    }

    public void exit()
    {
        Application.Quit();
    }
    public void credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
