using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    public GameObject secondBG;
    public float maxHeight, speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y + 9.24 >= maxHeight)
        {
            transform.position += new Vector3(0, speed, 0);
            if (secondBG.transform.position.y + 9.24 >= maxHeight)
                secondBG.transform.position += new Vector3(0, speed, 0);
            else
                secondBG.transform.position = new Vector3(0, 9.24f, 0);
        }
        else
            transform.position = new Vector3(0, 9.24f, 0);
    }
}