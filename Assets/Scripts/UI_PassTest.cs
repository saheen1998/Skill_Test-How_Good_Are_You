using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class UI_PassTest : MonoBehaviour
{
    public Text scoreText;

    void Start() {
        scoreText.text = GlobalController.newScore.ToString();
        switch(GlobalController.fromTest) {
            case 1: GlobalController.completedTest1 = true;
                GlobalController.scoreTest1 = GlobalController.newScore;
                if(GlobalController.newScore > GlobalController.highScoreTest1)
                    GlobalController.highScoreTest1 = GlobalController.newScore;
                if(GlobalController.currUser != "GUEST")
                    PlayGamesController.PostToLeaderboardTest1((long)GlobalController.newScore);
                break;
            case 2: GlobalController.completedTest2 = true;
                GlobalController.scoreTest2 = GlobalController.newScore;
                if(GlobalController.newScore > GlobalController.highScoreTest2)
                    GlobalController.highScoreTest2 = GlobalController.newScore;
                if(GlobalController.currUser != "GUEST")
                    PlayGamesController.PostToLeaderboardTest2((long)GlobalController.newScore);
                break;
            case 3: GlobalController.completedTest3 = true;
                GlobalController.scoreTest3 = GlobalController.newScore;
                break;
        }
    }

    public void GoBack() {
        SceneManager.LoadScene("Scene_TestMenu");
    }
    
    public void Restart() {
        GlobalController.newScore = 0;
        switch(GlobalController.fromTest) {
            case 1: SceneManager.LoadScene("Scene_Test1");
                break;
            case 2: SceneManager.LoadScene("Scene_Test2");
                break;
            case 3: SceneManager.LoadScene("Scene_Test3");
                break;
        }
    }
}
