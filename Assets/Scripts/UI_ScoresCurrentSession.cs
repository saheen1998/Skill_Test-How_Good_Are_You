using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_ScoresCurrentSession : MonoBehaviour
{
    public GameObject infoText;
    public Text textScore1;
    public Text textScore2;
    public Text textScore3;
    public Text textHighScore1;
    public Text textHighScore2;
    public Text textHighScore3;

    private Text infoTextComp;
    private Color c;

    void Start() {
        textScore1.text = "Recent: " + GlobalController.scoreTest1.ToString();
        textHighScore1.text = "High: " + GlobalController.highScoreTest1.ToString();
        textScore2.text = "Recent: " + GlobalController.scoreTest2.ToString();
        textHighScore2.text = "High: " + GlobalController.highScoreTest2.ToString();
        textScore3.text = "Recent: " + GlobalController.scoreTest3.ToString();
        textHighScore3.text = "High: " + GlobalController.highScoreTest3.ToString();

        infoTextComp = infoText.GetComponent<Text>();
        c = infoTextComp.color;
    }

    void FixedUpdate() {
        if(infoText.active == true && infoTextComp.color.a > 0){
            c.a -= 0.005f;
            infoTextComp.color = c;
        } else {
            c.a = 1;
            infoTextComp.color = c;
            infoText.SetActive(false);
        }
    }

    public void GoToScoresGraph() {
        //SceneManager.LoadScene("Scores_Graph");
    }
    
    public void GoToScoresLeaderboard() {
        if(GlobalController.currUser != "GUEST")
            PlayGamesController.ShowLeaderboardUI();
        else {
            c.a = 1;
            infoTextComp.color = c;
            infoText.SetActive(true);
        }
        //SceneManager.LoadScene("Scores_Leaderboard");
    }

    public void GoBackToMainMenu() {
        SceneManager.LoadScene("Scene_MainMenu");
    }
}
