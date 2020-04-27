using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_TestMenu : MonoBehaviour
{
    public Button performanceReportButton;
    public GameObject test1Status;
    public GameObject test2Status;
    public GameObject test3Status;

    public void Test1() {
        GlobalController.newScore = 0;
        Controller_Test1.numHoles = 30;
        Controller_Test1.timeMultiplier = 1;
        SceneManager.LoadScene("Scene_Test1");
    }
    
    public void Test2() {
        GlobalController.newScore = 0;
        SceneManager.LoadScene("Scene_Test2");
    }
    
    public void Test3() {
        GlobalController.newScore = 0;
        SceneManager.LoadScene("Scene_Test3");
    }
    
    public void GoBackToMainMenu() {
        SceneManager.LoadScene("Scene_MainMenu");
    }

    public void GoToPerformanceReport() {
        SceneManager.LoadScene("Scene_PerformanceReport");
    }

    void Start() {
        Screen.orientation = ScreenOrientation.Portrait;
        
        if(GlobalController.completedTest1)
            test1Status.SetActive(true);
        if(GlobalController.completedTest2)
            test2Status.SetActive(true);
        if(GlobalController.completedTest3)
            test3Status.SetActive(true);

        if(GlobalController.completedTest1 && GlobalController.completedTest2 && GlobalController.completedTest3)
            performanceReportButton.interactable = true;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GoBackToMainMenu();
        }
    }
}
