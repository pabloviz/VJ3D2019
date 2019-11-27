using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public int chunkLength;
    public int totalChunks;
    public GameObject[] chunks;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < totalChunks; ++i)
        {
            int j = (int)Random.Range(0, chunks.Length - 0.001f);
            GameObject ch;
            ch = Instantiate(chunks[j]) as GameObject;
            ch.transform.position = new Vector3(3.05f, 0, (i * chunkLength) + 9.38f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
