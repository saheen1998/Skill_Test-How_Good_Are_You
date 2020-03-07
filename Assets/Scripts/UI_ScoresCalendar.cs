using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_ScoresCalendar : MonoBehaviour
{

    public void GoToScoresGraph() {
        SceneManager.LoadScene("Scores_Graph");
    }
    
    public void GoToScoresLeaderboard() {
        SceneManager.LoadScene("Scores_Leaderboard");
    }

    public void GoBackToMainMenu() {
        SceneManager.LoadScene("Scene_MainMenu");
    }
}
