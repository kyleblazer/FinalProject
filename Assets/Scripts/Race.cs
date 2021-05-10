using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Race : MonoBehaviour
{
    public int numRacers = 0;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public GameObject Player5;
    public GameObject Player6;
    public GameObject Player7;
    public GameObject Player8;
    public GameObject Player9;
    private GameObject[] playerArray;
    public GameObject timer;
    public GameObject startText;
    public GameObject startButton;
    public GameObject addText;
    public GameObject addButton;
    public GameObject endRaceButton;
    public GameObject P1Split;
    public GameObject P1End;
    public GameObject editButton;
    public Text timerText;
    private float raceStartTime = 0f;
    public float m_time;


    public float GetTime()
    {
        return m_time;
    }

    // Start is called before the first frame update
    void Start()
    {
        raceStartTime = Time.time;
        playerArray = new GameObject[9];
        playerArray[0] = Player1;
        playerArray[1] = Player2;
        playerArray[2] = Player3;
        playerArray[3] = Player4;
        playerArray[4] = Player5;
        playerArray[5] = Player6;
        playerArray[6] = Player7;
        playerArray[7] = Player8;
        playerArray[8] = Player9;
        P1Split.SetActive(false);
        P1End.SetActive(false);
        timer.SetActive(false);
        Player2.SetActive(false);
        Player3.SetActive(false);
        Player4.SetActive(false);
        Player5.SetActive(false);
        Player6.SetActive(false);
        Player7.SetActive(false);
        Player8.SetActive(false);
        Player9.SetActive(false);
        endRaceButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        m_time = Time.time - raceStartTime;
        TimeSpan ts = TimeSpan.FromSeconds(m_time);
        string result = ts.ToString("mm\\:ss\\.f");
        timerText.text = result; /*https://stackoverflow.com/questions/40867158/how-can-i-format-a-float-number-so-that-it-looks-like-real-time */
    }
    public void startRace()
    {
        startText.SetActive(false);
        startButton.SetActive(false);
        addText.SetActive(false);
        addButton.SetActive(false);
        timer.SetActive(true);
        endRaceButton.SetActive(true);
        P1Split.SetActive(true);
        P1End.SetActive(true);
        editButton.SetActive(false);
        raceStartTime = Time.time;

    }
    public void addPlayer()
    {
        if (numRacers < 9)
        {
            numRacers++;

        }

    }


}
