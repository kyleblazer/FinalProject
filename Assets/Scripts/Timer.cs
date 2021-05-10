using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text textBox;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }
    public void startTimer()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //TimeSpan ts = TimeSpan.FromSeconds(Time.time-startTime);
        //string result = ts.ToString("mm\\:ss\\.f");
        //textBox.text = result; /*https://stackoverflow.com/questions/40867158/how-can-i-format-a-float-number-so-that-it-looks-like-real-time */
    }
}
