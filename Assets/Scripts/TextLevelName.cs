
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLevelName : MonoBehaviour
{
    public RectTransform rt;
    public int level;
    public Text t;
    // Start is called before the first frame update
    void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();

        t = gameObject.GetComponent<Text>();

        if (level == 1)
        {
            t.text = "HELL ESCAPE";
        }
        else if (level == 2)
        {
            t.text = "MOUNTAIN TRAIL";
        }
        else if (level == 3)
        {
            t.text = "HEAVEN'S DOOR";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = rt.localPosition;
        if (pos.x > 50) rt.localPosition = new Vector3(pos.x - 10, pos.y, pos.z);
        else if (pos.x > -50) rt.localPosition = new Vector3(pos.x - 2, pos.y, pos.z);
        else if (pos.x > -1000) rt.localPosition = new Vector3(pos.x - 10, pos.y, pos.z);
        else gameObject.SetActive(false);
    }
}
