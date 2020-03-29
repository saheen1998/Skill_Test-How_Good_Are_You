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
    public Text highScoreText;
    public GameObject infoText;

    void Start() {
        Screen.orientation = ScreenOrientation.Portrait;
        scoreText.text = GlobalController.newScore.ToString();

        if(GlobalController.currUser == "GUEST") {
            infoText.SetActive(true);
        }

        switch(GlobalController.fromTest) {
            case 1: GlobalController.AddNewScoreTest1(GlobalController.newScore);
                highScoreText.text = GlobalController.highScoreTest1.ToString();
                break;

            case 2: GlobalController.AddNewScoreTest2(GlobalController.newScore);
                highScoreText.text = GlobalController.highScoreTest2.ToString();
                break;

            case 3: GlobalController.AddNewScoreTest3(GlobalController.newScore);
                highScoreText.text = GlobalController.highScoreTest3.ToString();
                break;
        }
    }

    public void GoBack() {
        SceneManager.LoadScene("Scene_TestMenu");
    }
    
    public void Restart() {
        GlobalController.newScore = 0;
        switch(GlobalController.fromTest) {
            case 1: Controller_Test1.numHoles = 30;
                Controller_Test1.timeMultiplier = 1;
                SceneManager.LoadScene("Scene_Test1");
                break;
            case 2: SceneManager.LoadScene("Scene_Test2");
                break;
            case 3: SceneManager.LoadScene("Scene_Test3");
                break;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GoBack();
        }
    }
}
