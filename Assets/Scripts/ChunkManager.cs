using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    private float chunkCenter;
    private float chunkLength;
    public int totalChunks;
    public GameObject[] chunks;
    public GameObject startChunk;
    public GameObject endChunk;
    // Start is called before the first frame update
    void Start()
    {
        
        startChunk = Instantiate(startChunk) as GameObject;
        startChunk.transform.position = new Vector3(0, 0, 0);
        float last_y = 22.0f;
        for (int i = 0; i < totalChunks; ++i) { 
        
            int j = (int)Random.Range(0, chunks.Length - 0.001f);
            GameObject ch;
            ch = Instantiate(chunks[j]) as GameObject;
            chunkLength = ch.transform.Find("Ground").GetComponent<BoxCollider>().bounds.size.z;
            chunkCenter = ch.transform.Find("Ground").GetComponent<BoxCollider>().bounds.center.z;
            //Debug.Log(chunkLength);
            //Debug.Log(chunkCenter);
            ch.transform.position = new Vector3(0, 0, last_y);// + chunkCenter);
            last_y += chunkLength;
            if (ch.tag == "no-ground") ch.transform.Find("Ground").gameObject.SetActive(false);
        }

        endChunk = Instantiate(endChunk) as GameObject;
        endChunk.transform.position = new Vector3(0, 0, last_y + 18.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
