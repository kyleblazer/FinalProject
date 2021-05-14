using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class Race : MonoBehaviour
{
    public int numRacers = 0;
    public GameObject showLeaderboard;
    public Player Player1;
    public Player Player2;
    public Player Player3;
    public Player Player4;
    public Player Player5;
    public Player Player6;
    public Player Player7;
    public Player Player8;
    public Player Player9;
    public Player Player10;
    public GameObject P1EditButton;
    public GameObject P2EditButton;
    public GameObject P3EditButton;
    public GameObject P4EditButton;
    public GameObject P5EditButton;
    public GameObject P6EditButton;
    public GameObject P7EditButton;
    public GameObject P8EditButton;
    public GameObject P9EditButton;
    public GameObject P10EditButton;
    private Player[] playerArray;
    public GameObject startText;
    public GameObject startButton;
    public GameObject addText;
    public GameObject addButton;
    public GameObject endRaceButton;
    //public GameObject P1Split;
    //public GameObject P1End;
    //public GameObject editButton;
    Timer t;
    public Text timerTextBox;
    public GameObject inputFieldText;
    public GameObject inputFieldBox;
    public string playerNameInput;
    public GameObject saveButton;
    private Player playerToEdit;
    private TouchScreenKeyboard keyboard;
    public GameObject leaderboardButton;
    public GameObject leaderboardTextBox;
    public string leaderboardText = "Leaderboard:\n";
    public GameObject closeLeaderboardButton;
    public GameObject lapText;
    public string lapTextString = "";
    public GameObject leaveRaceButton;
    public GameObject restartRaceButton;
    public GameObject doNotRestartRaceButton;
    public GameObject leaderboardNumbers;
    Statistics s;
    private bool r1Ended = false;
    private bool r2Ended = false;
    private bool r3Ended = false;
    private bool r4Ended = false;
    private bool r5Ended = false;
    private bool r6Ended = false;
    private bool r7Ended = false;
    private bool r8Ended = false;
    private bool r9Ended = false;
    private bool r10Ended = false;

    // Start is called before the first frame update
    void Start()
    {
        leaderboardNumbers.SetActive(false);
        GameObject gameObject = new GameObject("Statistics");
        s = gameObject.AddComponent<Statistics>();
        restartRaceButton.SetActive(false);
        doNotRestartRaceButton.SetActive(false);
        leaveRaceButton.SetActive(false);
        showLeaderboard.SetActive(false);
        timerTextBox.gameObject.SetActive(false);
        Player p = gameObject.GetComponent<Player>();
        GameObject gameObject2 = new GameObject("Timer");
        t = gameObject2.AddComponent<Timer>();
        playerArray = new Player[10];
        playerArray[0] = Player1;
        playerArray[1] = Player2;
        playerArray[2] = Player3;
        playerArray[3] = Player4;
        playerArray[4] = Player5;
        playerArray[5] = Player6;
        playerArray[6] = Player7;
        playerArray[7] = Player8;
        playerArray[8] = Player9;
        playerArray[9] = Player10;
        hideInputField();
        hideSaveButton();
        leaderboardTextBox.SetActive(false);
        leaderboardButton.SetActive(false);
        closeLeaderboardButton.SetActive(false);
        lapText.SetActive(false);
        for (int i=0; i<10; ++i)
        {
            playerArray[i].hideEntirePlayer();
        }
        endRaceButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan ts = TimeSpan.FromSeconds(t.getCurrentTime());
        string result = ts.ToString("mm\\:ss\\.f");
        timerTextBox.text = result; /*https://stackoverflow.com/questions/40867158/how-can-i-format-a-float-number-so-that-it-looks-like-real-time */
    }

    public void showLeaderboardScreen()
    {
        leaderboardNumbers.GetComponent<Text>().text += "Place:\n";
        closeLeaderboardButton.SetActive(true);
        leaderboardButton.SetActive(false);
        leaderboardTextBox.SetActive(true);
        leaderboardNumbers.SetActive(true);
        //find player with fastest lap
        for (int i = 1; i <= numRacers; ++i)
        {
            leaderboardNumbers.GetComponent<Text>().text += i.ToString() + "\n";
        }
        leaderboardTextBox.GetComponent<Text>().text = leaderboardText;
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideSplitButton();
            playerArray[i].hideEndButton();
            playerArray[i].hidePlayerName();
            playerArray[i].hideSeeStatsButton();
        }
    }
    public void hideLeaderboardScreen()
    {
        leaderboardButton.SetActive(true);
        leaderboardTextBox.SetActive(false);
        leaderboardNumbers.SetActive(false);
        closeLeaderboardButton.SetActive(false);
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].showPlayerName();
            playerArray[i].showSeeStatsButton();
        }
    }
    public void onRestartRaceButtonClick()
    {
        leaveRaceButton.SetActive(false);
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideSplitButton();
            playerArray[i].hideEndButton();
            playerArray[i].hidePlayerName();
            playerArray[i].hideSeeStatsButton();
        }
        leaderboardButton.SetActive(false);
        restartRaceButton.SetActive(true);
        doNotRestartRaceButton.SetActive(true);
    }
    public void SaveButton()
    {
        keyboard = null;
        playerNameInput = inputFieldText.GetComponent<Text>().text;
        playerToEdit.saveName(playerNameInput);
        for (int i = 0; i < numRacers; ++i)
        {
            playerArray[i].gameObject.SetActive(true);
            playerArray[i].hideSplitButton();
            playerArray[i].hideEndButton();

        }
        hideInputField();
        hideSaveButton();
        startText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        addText.gameObject.SetActive(true);
        addButton.gameObject.SetActive(true);
    }

    public void goBackToFinishList()
    {
        for (int i = 0; i < numRacers; ++i)
        {
            playerArray[i].showPlayerName();
            playerArray[i].showSeeStatsButton();
        }
        leaderboardButton.SetActive(true);
        restartRaceButton.SetActive(false);
        doNotRestartRaceButton.SetActive(false);

    }
    public void startRace()
    {
        if (numRacers > 0)
        {
            timerTextBox.gameObject.SetActive(true);
            t.startTimer();
            startText.SetActive(false);
            startButton.SetActive(false);
            addText.SetActive(false);
            addButton.SetActive(false);
            endRaceButton.SetActive(true);
            lapText.GetComponent<Text>().text = lapTextString;
            lapText.SetActive(true);
            for (int i = 0; i < numRacers; ++i)
            {
                playerArray[i].startPlayerRace();
                playerArray[i].hideEditButton();
                playerArray[i].showSplitButton();
                playerArray[i].showEndButton();
                playerArray[i].showLapText();
            }
        }
        else
        {
            Debug.Log("No racers added yet");
        }


    }
    public void addPlayer()
    {
        if (numRacers < 10)
        {
            playerArray[numRacers].gameObject.SetActive(true);
            playerArray[numRacers].hideSplitButton();
            playerArray[numRacers].hideEndButton();
            playerArray[numRacers].hideStatsButton();
            playerArray[numRacers].hideLapButton();
            playerArray[numRacers].hideStatsText();
            playerArray[numRacers].hideCloseStatsButton();
            playerArray[numRacers].hideSeeStatsButton();
            playerArray[numRacers].hideLapText();
            numRacers++;
            lapTextString += "Lap #\n\n\n";
        }
        else
        {
            Debug.Log("Max players reached");
        }
    }

    public void endRaceAndGoToStats()
    {
        for (int i = 0; i < numRacers; ++i)
        {
            playerArray[i].hideSplitButton();
            playerArray[i].hideEndButton();
            playerArray[i].hidePlayerName();
            playerArray[i].showPlayerName();
            playerArray[i].showSeeStatsButton();
            playerArray[i].hideLapText();
        }
        timerTextBox.gameObject.SetActive(false);
        endRaceButton.SetActive(false);
        leaderboardButton.SetActive(true);
        lapText.SetActive(false);
        leaveRaceButton.SetActive(true);
        restartRaceButton.SetActive(false);
        doNotRestartRaceButton.SetActive(false);
    }
    public void hideInputField()
    {
        inputFieldText.SetActive(false);
        inputFieldBox.SetActive(false);
    }
    public void showInputField()
    {
        inputFieldText.SetActive(true);
        inputFieldBox.SetActive(true);
    }
    public void hideSaveButton()
    {
        saveButton.SetActive(false);
    }
    public void showSaveButton()
    {
        saveButton.SetActive(true);
    }
    public void editName1()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideEntirePlayer();
        }
        showInputField();
        playerToEdit = Player1;
        showSaveButton();
        startText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        addText.gameObject.SetActive(false);
        addButton.gameObject.SetActive(false);
    }
    public void editName2()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideEntirePlayer();
        }
        showInputField();
        playerToEdit = Player2;
        showSaveButton();
        startText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        addText.gameObject.SetActive(false);
        addButton.gameObject.SetActive(false);
    }
    public void editName3()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideEntirePlayer();
        }
        showInputField();
        playerToEdit = Player3;
        showSaveButton();
        startText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        addText.gameObject.SetActive(false);
        addButton.gameObject.SetActive(false);
    }
    public void editName4()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideEntirePlayer();
        }
        showInputField();
        playerToEdit = Player4;
        showSaveButton();
        startText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        addText.gameObject.SetActive(false);
        addButton.gameObject.SetActive(false);
    }
    public void editName5()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideEntirePlayer();
        }
        showInputField();
        playerToEdit = Player5;
        showSaveButton();
        startText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        addText.gameObject.SetActive(false);
        addButton.gameObject.SetActive(false);
    }
    public void editName6()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideEntirePlayer();
        }
        showInputField();
        playerToEdit = Player6;
        showSaveButton();
        startText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        addText.gameObject.SetActive(false);
        addButton.gameObject.SetActive(false);
    }
    public void editName7()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideEntirePlayer();
        }
        showInputField();
        playerToEdit = Player7;
        showSaveButton();
        startText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        addText.gameObject.SetActive(false);
        addButton.gameObject.SetActive(false);
    }
    public void editName8()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideEntirePlayer();
        }
        showInputField();
        playerToEdit = Player8;
        showSaveButton();
        startText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        addText.gameObject.SetActive(false);
        addButton.gameObject.SetActive(false);
    }
    public void editName9()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideEntirePlayer();
        }
        showInputField();
        playerToEdit = Player9;
        showSaveButton();
        startText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        addText.gameObject.SetActive(false);
        addButton.gameObject.SetActive(false);
    }
    public void editName10()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideEntirePlayer();
        }
        showInputField();
        playerToEdit = Player10;
        showSaveButton();
        startText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        addText.gameObject.SetActive(false);
        addButton.gameObject.SetActive(false);
    }
    public void showStats1()
    {
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideSplitButton();
            playerArray[i].hideEndButton();
            playerArray[i].hidePlayerName();
            playerArray[i].hideSeeStatsButton();
        }
        leaderboardButton.SetActive(false);
        leaveRaceButton.SetActive(false);
        Player1.onSeeStatsClick();
    }
    public void showStats2()
    {
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideSplitButton();
            playerArray[i].hideEndButton();
            playerArray[i].hidePlayerName();
            playerArray[i].hideSeeStatsButton();
        }
        leaderboardButton.SetActive(false);
        leaveRaceButton.SetActive(false);
        Player2.onSeeStatsClick();
    }
    public void showStats3()
    {
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideSplitButton();
            playerArray[i].hideEndButton();
            playerArray[i].hidePlayerName();
            playerArray[i].hideSeeStatsButton();
        }
        leaderboardButton.SetActive(false);
        leaveRaceButton.SetActive(false);
        Player3.onSeeStatsClick();
    }
    public void showStats4()
    {
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideSplitButton();
            playerArray[i].hideEndButton();
            playerArray[i].hidePlayerName();
            playerArray[i].hideSeeStatsButton();
        }
        leaveRaceButton.SetActive(false);
        leaderboardButton.SetActive(false);
        Player4.onSeeStatsClick();
    }
    public void showStats5()
    {
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideSplitButton();
            playerArray[i].hideEndButton();
            playerArray[i].hidePlayerName();
            playerArray[i].hideSeeStatsButton();
        }
        leaveRaceButton.SetActive(false);
        leaderboardButton.SetActive(false);
        Player5.onSeeStatsClick();
    }
    public void showStats6()
    {
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideSplitButton();
            playerArray[i].hideEndButton();
            playerArray[i].hidePlayerName();
            playerArray[i].hideSeeStatsButton();
        }
        leaveRaceButton.SetActive(false);
        leaderboardButton.SetActive(false);
        Player6.onSeeStatsClick();
    }
    public void showStats7()
    {
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideSplitButton();
            playerArray[i].hideEndButton();
            playerArray[i].hidePlayerName();
            playerArray[i].hideSeeStatsButton();
        }
        leaveRaceButton.SetActive(false);
        leaderboardButton.SetActive(false);
        Player7.onSeeStatsClick();
    }
    public void showStats8()
    {
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideSplitButton();
            playerArray[i].hideEndButton();
            playerArray[i].hidePlayerName();
            playerArray[i].hideSeeStatsButton();
        }
        leaveRaceButton.SetActive(false);
        leaderboardButton.SetActive(false);
        Player8.onSeeStatsClick();
    }
    public void showStats9()
    {
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideSplitButton();
            playerArray[i].hideEndButton();
            playerArray[i].hidePlayerName();
            playerArray[i].hideSeeStatsButton();
        }
        leaveRaceButton.SetActive(false);
        leaderboardButton.SetActive(false);
        Player9.onSeeStatsClick();
    }
    public void showStats10()
    {
        for (int i = 0; i < 10; ++i)
        {
            playerArray[i].hideSplitButton();
            playerArray[i].hideEndButton();
            playerArray[i].hidePlayerName();
            playerArray[i].hideSeeStatsButton();
        }
        leaveRaceButton.SetActive(false);
        leaderboardButton.SetActive(false);
        Player10.onSeeStatsClick();
    }
    public void p1finish()
    {
        if (r1Ended == false){
            string player = playerArray[0].getName();
            leaderboardText += player + ": " + s.findTotalLapTime(playerArray[0].getLapArray()) + "\n";
            r1Ended = true;
        }
    }
    public void p2finish()
    {
        if (r2Ended == false)
        {
            string player = playerArray[1].getName();
            leaderboardText += player + ": " + s.findTotalLapTime(playerArray[1].getLapArray()) + "\n";
            r2Ended = true;
        }
    }
    public void p3finish()
    {
        if (r3Ended == false)
        {
            string player = playerArray[2].getName();
            leaderboardText += player + ": " + s.findTotalLapTime(playerArray[2].getLapArray()) + "\n";
            r3Ended = true;
        }
    }
    public void p4finish()
    {
        if (r4Ended == false)
        {
            string player = playerArray[3].getName();
            leaderboardText += player + ": " + s.findTotalLapTime(playerArray[3].getLapArray()) + "\n";
            r4Ended = true;
        }
    }
    public void p5finish()
    {
        if (r5Ended == false)
        {
            string player = playerArray[4].getName();
            leaderboardText += player + ": " + s.findTotalLapTime(playerArray[4].getLapArray()) + "\n";
            r5Ended = true;
        }
    }
    public void p6finish()
    {
        if (r6Ended == false)
        {
            string player = playerArray[5].getName();
            leaderboardText += player + ": " + s.findTotalLapTime(playerArray[5].getLapArray()) + "\n";
            r6Ended = true;
        }
    }
    public void p7finish()
    {
        if (r7Ended == false)
        {
            string player = playerArray[6].getName();
            leaderboardText += player + ": " + s.findTotalLapTime(playerArray[6].getLapArray()) + "\n";
            r7Ended = true;
        }
    }
    public void p8finish()
    {
        if (r8Ended == false)
        {
            string player = playerArray[7].getName();
            leaderboardText += player + ": " + s.findTotalLapTime(playerArray[7].getLapArray()) + "\n";
            r8Ended = true;
        }
    }
    public void p9finish()
    {
        if (r9Ended == false)
        {
            string player = playerArray[8].getName();
            leaderboardText += player + ": " + s.findTotalLapTime(playerArray[8].getLapArray()) + "\n";
            r9Ended = true;
        }
    }
    
    public void p10finish()
    {
        if (r10Ended == false)
        {
            string player = playerArray[9].getName();
            leaderboardText += player + ": " + s.findTotalLapTime(playerArray[9].getLapArray()) + "\n";
            r1Ended = true;
        }
    }


    public void hideStats()
    {
        for (int i = 0; i < numRacers; ++i)
        {
            playerArray[i].showPlayerName();
            playerArray[i].showSeeStatsButton();
            playerArray[i].onCloseStatsClick();
        }
        leaderboardButton.SetActive(true);
        leaveRaceButton.SetActive(true);
    }
    public void restartApplication(string SceneName)
    {
        SceneManager.LoadScene("Start Scene");
    }
}
