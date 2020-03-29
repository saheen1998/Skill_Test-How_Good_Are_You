using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_FailTest : MonoBehaviour
{
    public void GoBack() {
        SceneManager.LoadScene("Scene_TestMenu");
    }

    public void Restart() {
        GlobalController.newScore = 0;
        switch(GlobalController.fromTest) {
            case -1: Controller_Test1.numHoles = 30;
                    Controller_Test1.timeMultiplier = 1;
                    SceneManager.LoadScene("Scene_Test1");
                break;
            case -2: SceneManager.LoadScene("Scene_Test2");
                break;
            case -3: SceneManager.LoadScene("Scene_Test3");
                break;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GoBack();
        }
    }
}
