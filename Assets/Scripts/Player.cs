using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    public GameObject player;
    public Button splitButton;
    public Button endButton;
    public Button editButton;
    Statistics s;
    Timer t;
    public LinkedList<float> playerTimes = new LinkedList<float>();
    private float lastLap;
    private string playerStats = "";
    public float[] array;
    public string playerName;
    public Text playerNameTextBox;
    public Text statsText;
    public GameObject lapButton;
    public GameObject statsButton;
    public GameObject closeStatsButton;
    public GameObject seeStatsButton;
    public bool hasRaceBeenEnded = false;
    public int numLaps = 0;
    public GameObject numLapsText;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = new GameObject("Statistics");
        s = gameObject.AddComponent<Statistics>();
        GameObject gameObject2 = new GameObject("Timer");
        t = gameObject2.AddComponent<Timer>();
    }
    public string getName()
    {
        return playerNameTextBox.GetComponent<Text>().text;
    }
    public float[] getLapArray()
    {
        return array;
    }
    public void setNumLaps()
    {
        numLaps++;
    }
    public int getNumLaps()
    {
        return numLaps;
    }
    public void saveName(string nameInput)
    {
        playerName = nameInput;
        playerNameTextBox.text = nameInput;
    }

    public void startPlayerRace()
    {
        lastLap = Time.time;
    }

    public void recordSplit()
    {
        float thisLap = t.getCurrentTime();
        playerTimes.AddLast(thisLap - lastLap);
        lastLap = thisLap;
        numLaps++;
        numLapsText.GetComponent<Text>().text = numLaps.ToString();
    }
    public void onSeeStatsClick()
    {
        if (numLaps > 0)
        {
            hideSeeStatsButton();
            showStatsText();
            showCloseStatsButton();
            showLapButton();
            showStatsButton();
        }
        else
        {
            hideSeeStatsButton();
            showStatsText();
            showCloseStatsButton();
        }

    }
    public void onCloseStatsClick()
    {
        hideStatsText();
        hideCloseStatsButton();
        hideLapButton();
        hideStatsButton();
    }
    public void showLaps()
    {
        playerStats = "";
        int count = 1;
        foreach (var item in array)
        {
            int minutes = (int)item / 60;
            int seconds = (int)item - 60 * minutes;
            int milliseconds = (int)(1000 * (item - minutes * 60 - seconds));
            string lapTime = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
            playerStats += "Lap " + count.ToString() + " time:  " + lapTime + "\n";
            count++;
         }
        statsText.GetComponent<Text>().text = playerStats;

    }
    public void showStats()
    {
        playerStats = "";
        array = ToArray();
        playerStats += "<b>"+playerNameTextBox.GetComponent<Text>().text + "'s Stats:"+ "</b>";
        playerStats += "\n";
        playerStats += "Number of laps: ";
        playerStats += numLaps.ToString();
        playerStats += "\n";
        playerStats += "Total time:";
        playerStats += "\n";
        playerStats += s.findTotalLapTime(array);
        playerStats += "\n";
        playerStats += "Average lap:";
        playerStats += "\n";
        playerStats += s.findAverageLap(array);
        playerStats += "\n";
        playerStats += "Fastest lap:";
        playerStats += "\n";
        playerStats += s.findFastestLap(array);
        playerStats += "\n";
        playerStats += "Slowest lap:";
        playerStats += "\n";
        playerStats += s.findSlowestLap(array);
        playerStats += "\n";
        playerStats += "Average lap variance:";
        playerStats += "\n";
        playerStats += s.findVariance(array);
        playerStats += "\n";
        statsText.GetComponent<Text>().text = playerStats;
    }
    public void endRace()
    {
        if (hasRaceBeenEnded == false)
        {
            hasRaceBeenEnded = true;
            recordSplit();
            showStats();
            string totalTime = s.findTotalLapTime(array);
            
        }
        else
        {
            Debug.Log("Race has already been ended");
        }
    }
    public string returnPlayerStats()
    {
        return "Player stats from player class";

    }
    public float[] ToArray()
    {
        float[] myArr = new float[100];
        playerTimes.CopyTo(myArr, 0);
        int countNotZero = 0;
        for (int i = 0; i < myArr.Length; ++i)
        {
            if (myArr[i] != 0)
            {
                countNotZero++;
            }
        }
        float[] timeArray = new float[countNotZero];
        for (int i = 0; i < countNotZero; ++i)
        {
            timeArray[i] = myArr[i];
        }
        return timeArray;
    }
    public void showLapText()
    {
        numLapsText.SetActive(true);
    }
    public void hideLapText()
    {
        numLapsText.SetActive(false);
    }
    public void hideEntirePlayer()
    {
        player.SetActive(false);
    }
    public void hideEditButton()
    {
        editButton.gameObject.SetActive(false);
    }
    public void showEditButton()
    {
        editButton.gameObject.SetActive(true);
    }
    public void hideSplitButton()
    {
        splitButton.gameObject.SetActive(false);
    }
    public void showSplitButton()
    {
        splitButton.gameObject.SetActive(true);
    }
    public void hideEndButton()
    {
        endButton.gameObject.SetActive(false);
    }
    public void showEndButton()
    {
        endButton.gameObject.SetActive(true);
    }
    public void hidePlayerName()
    {
        playerNameTextBox.gameObject.SetActive(false);
    }
    public void showPlayerName()
    {
        playerNameTextBox.gameObject.SetActive(true);
    }
    public void hideStatsText()
    {
        statsText.gameObject.SetActive(false);
    }
    public void showStatsText()
    {
        statsText.gameObject.SetActive(true);
    }
    public void hideLapButton()
    {
        lapButton.gameObject.SetActive(false);
    }
    public void showLapButton()
    {
        lapButton.gameObject.SetActive(true);
    }
    public void hideStatsButton()
    {
        statsButton.gameObject.SetActive(false);
    }
    public void showStatsButton()
    {
        statsButton.gameObject.SetActive(true);
    }
    public void hideCloseStatsButton()
    {
        closeStatsButton.gameObject.SetActive(false);
    }
    public void showCloseStatsButton()
    {
        closeStatsButton.gameObject.SetActive(true);
    }
    public void showSeeStatsButton()
    {
        seeStatsButton.gameObject.SetActive(true);
    }
    public void hideSeeStatsButton()
    {
        seeStatsButton.gameObject.SetActive(false);
    }
}