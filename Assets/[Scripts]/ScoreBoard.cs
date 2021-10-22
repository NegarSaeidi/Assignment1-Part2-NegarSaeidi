using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text sc;
    // Start is called before the first frame update
    void Start()
    {
        int temp = (int)PlayerPrefs.GetFloat("score");
        if (PlayerPrefs.HasKey("score"))
            sc.text = temp.ToString();
    }

   
}
