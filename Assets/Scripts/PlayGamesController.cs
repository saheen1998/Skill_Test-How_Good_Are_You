using System;
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

    void Awake() {

    }

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

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
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
            if (!success)
            {
                Debug.LogError("Unable to post new score to leaderboard");
            }
        });
    }

    public static void PostToLeaderboardTest2(long newScore)
    {
        Social.ReportScore(newScore, "CgkIx9zkzusWEAIQAQ", (bool success) => {
            if (!success)
            {
                Debug.LogError("Unable to post new score to leaderboard");
            }
        });
    }
    
    public static void PostToLeaderboardTest3(long newScore)
    {
        Social.ReportScore(newScore, "CgkIx9zkzusWEAIQBQ", (bool success) => {
            if (!success)
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

    public static IEnumerator GetLeaderboardScores(int leaderboardNo, Action<List<long>> onSuccess) {

        List<long> ret = new List<long>();
        long avgScore = -1;
        long playerScore = -1;
        long topScore = -1;
        string leaderboardId = "";

        switch(leaderboardNo) {
            case 1: leaderboardId = "CgkIx9zkzusWEAIQBA";
                    break;
            case 2: leaderboardId = "CgkIx9zkzusWEAIQAQ";
                    break;
            case 3: leaderboardId = "CgkIx9zkzusWEAIQBQ";
                    break;
        }

        PlayGamesPlatform.Instance.LoadScores(leaderboardId, LeaderboardStart.PlayerCentered,10,LeaderboardCollection.Public,LeaderboardTimeSpan.AllTime,
            (data) =>
            {
                if (!data.Valid)
                    avgScore = -1;
                else {
                    foreach (var item in data.Scores) {
                        //Debug.LogWarning("Score1: " + item.value);
                        avgScore += item.value;
                    }
                    avgScore /= data.Scores.Length;
                }
                playerScore = data.PlayerScore.value;
                /*Debug.LogWarning("Average Score: " + avgScore);
                Debug.Log (data.PlayerScore.userID);*/
                //Debug.Log (data.PlayerScore.formattedValue);
            }
        );

        PlayGamesPlatform.Instance.LoadScores(leaderboardId, LeaderboardStart.TopScores,1,LeaderboardCollection.Public,LeaderboardTimeSpan.AllTime,
            (data) =>
            {
                if (!data.Valid)
                    topScore = -1;
                else {
                    topScore = data.Scores[0].value;
                }
                Debug.Log(data.Scores[0].value);
            }
        );

        yield return new WaitForSeconds(2f);

        ret.Add(playerScore);
        ret.Add(avgScore);
        ret.Add(topScore);

        onSuccess(ret);
    }
}
