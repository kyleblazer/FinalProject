using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    public Button splitButton;
    public Button endButton;
    public Button editButton;
    Statistics s;
    public string playerName;
    public Text playerNameTextBox;
    public LinkedList<float> playerTimes = new LinkedList<float>();
    private float lastTime = 0f;
    public float timer;
    private TouchScreenKeyboard keyboard;
    private float startTime;
    private float raceStartTime = 0f;
    //public Text timerTextBox;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        GameObject gameObject = new GameObject("Statistics");
        s = gameObject.AddComponent<Statistics>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time - raceStartTime;
    }

    public void setName()
    {
        playerNameTextBox.text = playerName;
    }

    public string getName()
    {
        return playerName;
    }
    public void startRaceTimer()
    {
        raceStartTime = Time.time;
        //lastTime = Time.time;
    }
    public void recordSplit()
    {
        float thisLap = timer - lastTime;
        playerTimes.AddLast(thisLap);
        lastTime = timer;

    }
    public void endRace()
    {
        recordSplit();
        float[] array = ToArray();
        Debug.Log("Stats:");
        s.findAverageLap(array);
        s.findFastestLap(array);
        s.findSlowestLap(array);
        s.findVariance(array);

    }
    public float[] ToArray()
    {
        float[] myArr = new float[100];
        playerTimes.CopyTo(myArr, 0);
        int countNotZero = 0;
        for (int i= 0; i < myArr.Length; ++i)
        {
            if (myArr[i] != 0)
            {
                countNotZero++;
            }
        }
        float[] timeArray = new float[countNotZero];
        for (int i=0; i < countNotZero; ++i)
        {
            timeArray[i]=myArr[i];
        }
        return timeArray;
    }
   
}
