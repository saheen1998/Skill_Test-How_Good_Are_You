using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class UI_SignIn : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public Text mainText;
    public Text usernameText;
    private TouchScreenKeyboard keyboard;

    public void EnterText() {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.EmailAddress, false);
    }

    public void Continue() {
        if(passwordField.text == "wisc") {
            GlobalController.currUser = usernameField.text;
            SceneManager.LoadScene("Scene_MainMenu");
        }
    }
}
