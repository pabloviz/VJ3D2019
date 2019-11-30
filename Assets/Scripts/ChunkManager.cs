using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public float chunkCenter;
    public int chunkLength;
    public int totalChunks;
    public GameObject[] chunks;
    public GameObject startChunk;
    public GameObject endChunk;
    // Start is called before the first frame update
    void Start()
    {
        chunkCenter = 9.38f;
        startChunk = Instantiate(startChunk) as GameObject;
        startChunk.transform.position = new Vector3(3.05f, 0, chunkCenter);

        for (int i = 0; i < totalChunks; ++i)
        {
            int j = (int)Random.Range(0, chunks.Length - 0.001f);
            GameObject ch;
            ch = Instantiate(chunks[j]) as GameObject;
            ch.transform.position = new Vector3(3.05f, 0, ((i+1) * chunkLength) + chunkCenter);
        }

        endChunk = Instantiate(endChunk) as GameObject;
        endChunk.transform.position = new Vector3(3.05f, 0, ((totalChunks+1) * chunkLength) + chunkCenter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
