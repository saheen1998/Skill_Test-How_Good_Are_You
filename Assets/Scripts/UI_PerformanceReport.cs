using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_PerformanceReport : MonoBehaviour
{
    public Text reportText;

    void Start() {
        StartCoroutine(GetReport());
    }
    
    IEnumerator GetReport(){
        string reportStr = "";

        // For Test 1
        List<int> prevScores1 = GlobalController.GetPrevScoresTest1();
        if(prevScores1.Count == 1) {
            reportStr += "Since you have only tried test 1 once, there is not much we can say.";
        }
        else if(prevScores1.Count == 2) {
            if(prevScores1[0] > prevScores1[1])
                reportStr += "Your performance in test 1 has been improving.";
            else
                reportStr += "Your performance in test 1 has not been improving.";
        }
        else if(prevScores1.Count == 3) {
            if(prevScores1[0] > prevScores1[1] && prevScores1[0] > prevScores1[2])
                reportStr += "Your performance in test 1 has been improving.";
            else if(prevScores1[0] < prevScores1[1] && prevScores1[0] < prevScores1[2])
                reportStr += "Your performance in test 1 has been worsening.";
            else
                reportStr += "Your performance in test 1 has been consistent with your previous attempts.";
        }
        long avgScore1 = PlayGamesController.GetAvgScore1(this);
        yield return new WaitForSeconds(2f);
        if(avgScore1 != -1)
            reportStr += "\nThe average high score around your high score is " + avgScore1;
        
        // For Test 2
        List<int> prevScores2 = GlobalController.GetPrevScoresTest2();
        if(prevScores2.Count == 1) {
            reportStr += "\n\nSince you have only tried test 2 once, there is not much we can say.";
        }
        else if(prevScores2.Count == 2) {
            if(prevScores2[0] > prevScores2[1])
                reportStr += "\n\nYour performance in test 2 has been improving.";
            else
                reportStr += "\n\nYour performance in test 2 has not been improving.";
        }
        else if(prevScores2.Count == 3) {
            if(prevScores2[0] > prevScores2[1] && prevScores2[0] > prevScores2[2])
                reportStr += "\n\nYour performance in test 2 has been improving.";
            else if(prevScores2[0] < prevScores2[1] && prevScores2[0] < prevScores2[2])
                reportStr += "\n\nYour performance in test 2 has been worsening.";
            else
                reportStr += "\n\nYour performance in test 2 has been consistent with your previous attempts.";
        }
        /*long avgScore2 = PlayGamesController.GetLeaderboardScores2();
        if(avgScore2 != -1)
            reportStr += "\nThe average high score around your high score is" + avgScore2;*/

        // For Test 3
        List<int> prevScores3 = GlobalController.GetPrevScoresTest3();
        if(prevScores3.Count == 1) {
            reportStr += "\n\nSince you have only tried test 3 once, there is not much we can say.";
        }
        else if(prevScores3.Count == 2) {
            if(prevScores3[0] > prevScores3[1])
                reportStr += "\n\nYour performance in test 3 has been improving.";
            else
                reportStr += "\n\nYour performance in test 3 has not been improving.";
        }
        else if(prevScores3.Count == 3) {
            if(prevScores3[0] > prevScores3[1] && prevScores3[0] > prevScores3[2])
                reportStr += "\n\nYour performance in test 3 has been improving.";
            else if(prevScores3[0] < prevScores3[1] && prevScores3[0] < prevScores3[2])
                reportStr += "\n\nYour performance in test 3 has been worsening.";
            else
                reportStr += "\n\nYour performance in test 3 has been consistent with your previous attempts.";
        }
        /*long avgScore3 = PlayGamesController.GetLeaderboardScores3();
        if(avgScore3 != -1)
            reportStr += "\nThe average high score around your high score is" + avgScore3;*/

        reportText.text = reportStr.ToString();
    }

    public void GoBack() {
        SceneManager.LoadScene("Scene_TestMenu");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GoBack();
        }
    }
}
