using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class UI_ScoresLeaderboard : MonoBehaviour
{
    void Start() {
        PlayGamesController.ShowLeaderboardUI();
    }

    public void GoToScoresGraph() {
        SceneManager.LoadScene("Scores_Graph");
    }
    
    public void GoToScoresCalendar() {
        SceneManager.LoadScene("Scores_Calendar");
    }

    public void GoBackToMainMenu() {
        SceneManager.LoadScene("Scene_MainMenu");
    }

    /*public void ShowLeaderboardUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_score);
    }*/
}
