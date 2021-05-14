using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float startTime = 0f;
    private float currentTime;

    public void startTimer()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time - startTime;
    }
    public float getCurrentTime()
    {
        return currentTime;
    }
}
