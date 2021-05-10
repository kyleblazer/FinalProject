using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void goToEditPlayer(string SceneName)
    {
        SceneManager.LoadScene("Edit Scene");
    }
    public void goToLeaderBoard(string SceneName)
    {
        SceneManager.LoadScene("Leaderboard Scene");
    }
    public void goToIndividualTimes(string SceneName)
    {
        SceneManager.LoadScene("Individual Times Scene");
    }
    public void goToStartScene(string SceneName)
    {
        SceneManager.LoadScene("Start Scene");
    }
    public void goToMidRaceScene(string SceneName)
    {
        SceneManager.LoadScene("Mid Race Scene");
    }
}
