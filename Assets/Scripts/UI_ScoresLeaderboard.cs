using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_ScoresLeaderboard : MonoBehaviour
{

    public void GoToScoresGraph() {
        SceneManager.LoadScene("Scores_Graph");
    }
    
    public void GoToScoresCalendar() {
        SceneManager.LoadScene("Scores_Calendar");
    }

    public void GoBackToMainMenu() {
        SceneManager.LoadScene("Scene_MainMenu");
    }
}
