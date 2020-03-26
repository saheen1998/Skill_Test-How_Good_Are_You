using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGamesController : MonoBehaviour {

    public Text mainText;
    public Button signOutButton;
    public Text usernameText;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        
        usernameText.text = "Logged in as " + GlobalController.currUser;
        if(GlobalController.currUser == "GUEST") {
            signOutButton.interactable = false;
        } else {
            signOutButton.interactable = true;
        }
    }
    
    public void AuthenticateUser()
    {
        mainText.text = "Logging in...";
        mainText.color = Color.green;
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success == true)
            {
                Debug.Log("Logged in to Google Play Games Services");
                GlobalController.currUser = Social.localUser.userName;

                SceneManager.LoadScene("Scene_MainMenu");
            }
            else
            {
                Debug.LogError("Unable to sign in to Google Play Games Services");
                mainText.text = "Could not login to Google Play Games Services";
                mainText.color = Color.red;
            }
        });
        
    }

    public void SignOut() {
        mainText.text = "Logged out";
        mainText.color = Color.green;
        PlayGamesPlatform.Instance.SignOut();
        GlobalController.currUser = "GUEST";
        signOutButton.interactable = false;
        usernameText.text = "Logged in as " + GlobalController.currUser;
    }

    public void ContinueAsGuest() {
        GlobalController.currUser = "GUEST";
        SignOut();
        SceneManager.LoadScene("Scene_MainMenu");
    }

    public static void PostToLeaderboardTest1(long newScore)
    {
        Social.ReportScore(newScore, "CgkIx9zkzusWEAIQBA", (bool success) => {
            if (success)
            {
                Debug.Log("Posted new score to leaderboard");
            }
            else
            {
                Debug.LogError("Unable to post new score to leaderboard");
            }
        });
    }

    public static void PostToLeaderboardTest2(long newScore)
    {
        Social.ReportScore(newScore, "CgkIx9zkzusWEAIQAQ", (bool success) => {
            if (success)
            {
                Debug.Log("Posted new score to leaderboard");
            }
            else
            {
                Debug.LogError("Unable to post new score to leaderboard");
            }
        });
    }
    
    public static void PostToLeaderboardTest3(long newScore)
    {
        Social.ReportScore(newScore, "CgkIx9zkzusWEAIQBQ", (bool success) => {
            if (success)
            {
                Debug.Log("Posted new score to leaderboard");
            }
            else
            {
                Debug.LogError("Unable to post new score to leaderboard");
            }
        });
    }

    public static void ShowLeaderboardUI()
    {
        //PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_score);
        Social.ShowLeaderboardUI();
    }
}
