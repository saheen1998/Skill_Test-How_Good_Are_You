using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_PerformanceReport : MonoBehaviour
{
    public Text reportText;
    public GameObject infoText;

    private Text infoTextComp;
    private Color c;

    void Start() {
        StartCoroutine(GetReport());

        infoTextComp = infoText.transform.GetChild(0).GetComponent<Text>();
        c = infoTextComp.color;

        if(GlobalController.currUser == "GUEST"){
            infoText.SetActive(true);
            c.a = 1;
            infoTextComp.color = c;
        }
    }
    
    void FixedUpdate() {
        if(infoText.activeSelf == true && infoTextComp.color.a > 0){
            c.a -= 0.01f;
            infoTextComp.color = c;
        } else {
            c.a = 1;
            infoTextComp.color = c;
            infoText.SetActive(false);
        }
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
        yield return this.StartCoroutine(PlayGamesController.GetLeaderboardScores( 1,
            (scores) => {
                if(scores[0] != -1 && scores[1] != -1 && scores[2] != -1) {
                    
                    reportStr += "\nThe average high score around your high score of " + scores[0] + " is " + scores[1] + ".";

                    float percent = scores[0] / (float)scores[2];
                    if(percent > 0.8f)
                        reportStr += "\nAccording to your high score your hand-eye coordination is excellent! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else if(percent > 0.6f)
                        reportStr += "\nAccording to your high score your hand-eye coordination is good! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else if(percent > 0.4f)
                        reportStr += "\nAccording to your high score your hand-eye coordination is average! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else
                        reportStr += "\nAccording to your high score your hand-eye coordination is below average! Your percentile is " + (percent * 100).ToString("F0") + "!";

                    percent = GlobalController.scoreTest1 / (float)scores[2];
                    if(percent > 0.8f)
                        reportStr += "\nAccording to your most recent score your hand-eye coordination is excellent! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else if(percent > 0.6f)
                        reportStr += "\nAccording to your most recent score your hand-eye coordination is good! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else if(percent > 0.4f)
                        reportStr += "\nAccording to your most recent score your hand-eye coordination is average! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else
                        reportStr += "\nAccording to your most recent score your hand-eye coordination is below average! Your percentile is " + (percent * 100).ToString("F0") + "!";
                }
            }));
        
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
        yield return this.StartCoroutine(PlayGamesController.GetLeaderboardScores( 2,
            (scores) => {
                if(scores[0] != -1 && scores[1] != -1 && scores[2] != -1) {
                    
                    reportStr += "\nThe average high score around your high score of " + scores[0] + " is " + scores[1] + ".";

                    float percent = scores[0] / (float)scores[2];
                    if(percent > 0.8f)
                        reportStr += "\nAccording to your high score your reaction time is excellent! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else if(percent > 0.6f)
                        reportStr += "\nAccording to your high score your reaction time is good! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else if(percent > 0.4f)
                        reportStr += "\nAccording to your high score your reaction time is average! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else
                        reportStr += "\nAccording to your high score your reaction time is below average! Your percentile is " + (percent * 100).ToString("F0") + "!";

                    percent = GlobalController.scoreTest2 / (float)scores[2];
                    if(percent > 0.8f)
                        reportStr += "\nAccording to your most recent score your reaction time is excellent! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else if(percent > 0.6f)
                        reportStr += "\nAccording to your most recent score your reaction time is good! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else if(percent > 0.4f)
                        reportStr += "\nAccording to your most recent score your reaction time is average! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else
                        reportStr += "\nAccording to your most recent score your reaction time is below average! Your percentile is " + (percent * 100).ToString("F0") + "!";
                }
            }));

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
        yield return this.StartCoroutine(PlayGamesController.GetLeaderboardScores( 3,
            (scores) => {
                if(scores[0] != -1 && scores[1] != -1 && scores[2] != -1) {
                    
                    reportStr += "\nThe average high score around your high score of " + scores[0] + " is " + scores[1] + ".";

                    float percent = scores[0] / (float)scores[2];
                    if(percent > 0.8f)
                        reportStr += "\nAccording to your high score your multi-tasking skill is excellent! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else if(percent > 0.6f)
                        reportStr += "\nAccording to your high score your multi-tasking skill is good! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else if(percent > 0.4f)
                        reportStr += "\nAccording to your high score your multi-tasking skill is average! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else
                        reportStr += "\nAccording to your high score your multi-tasking skill is below average! Your percentile is " + (percent * 100).ToString("F0") + "!";

                    percent = GlobalController.scoreTest3 / (float)scores[2];
                    if(percent > 0.8f)
                        reportStr += "\nAccording to your most recent score your multi-tasking skill is excellent! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else if(percent > 0.6f)
                        reportStr += "\nAccording to your most recent score your multi-tasking skill is good! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else if(percent > 0.4f)
                        reportStr += "\nAccording to your most recent score your multi-tasking skill is average! Your percentile is " + (percent * 100).ToString("F0") + "!";
                    else
                        reportStr += "\nAccording to your most recent score your multi-tasking skill is below average! Your percentile is " + (percent * 100).ToString("F0") + "!";
                }
            }));

        reportText.text = reportStr.ToString();
    }

    public void GoBack() {
        SceneManager.LoadScene("Scene_TestMenu");
    }

    public void ViewScores() {
        SceneManager.LoadScene("Scores_CurrentSession");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GoBack();
        }
    }
}
