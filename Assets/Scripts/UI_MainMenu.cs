using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    public Text usernameText;
    void Start() {
        usernameText.text = "Logged in as " + GlobalController.currUser;
    }
    public void StartTest() {
        SceneManager.LoadScene("Scene_TestMenu");
    }

    public void ViewScores() {
        SceneManager.LoadScene("Scores_Graph");
    }

    public void ChangeUser() {
        SceneManager.LoadScene("Scene_SignIn");
    }
}
