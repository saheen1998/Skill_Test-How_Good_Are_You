using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_SignIn : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    private TouchScreenKeyboard keyboard;

    public void EnterText() {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.EmailAddress, false);
    }

    public void Continue() {
        GlobalController.currUser = usernameField.text;
        SceneManager.LoadScene("Scene_MainMenu");
    }
}
