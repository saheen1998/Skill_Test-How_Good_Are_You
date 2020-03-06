using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_PassTest : MonoBehaviour
{
    public Text scoreText;

    void Start() {
        scoreText.text = GlobalController.newScore.ToString();
        switch(GlobalController.fromTest) {
            case 1: GlobalController.completedTest1 = true;
                break;
            case 2: GlobalController.completedTest2 = true;
                break;
            case 3: GlobalController.completedTest3 = true;
                break;
        }
    }

    public void GoBack() {
        SceneManager.LoadScene("Scene_TestMenu");
    }
}
