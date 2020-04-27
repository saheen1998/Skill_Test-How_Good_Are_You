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

    private static long avgScore1 = 0;
    private static long avgScore2 = 0;
    private static long avgScore3 = 0;

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

    public static long GetAvgScore1(MonoBehaviour instance) {
        instance.StartCoroutine(GetLeaderboardScores1());
        return avgScore1;
    }

    static IEnumerator GetLeaderboardScores1() {

        string mStatus;
        long avgScore = -1;

        PlayGamesPlatform.Instance.LoadScores("CgkIx9zkzusWEAIQBA",LeaderboardStart.PlayerCentered,10,LeaderboardCollection.Public,LeaderboardTimeSpan.AllTime,
            (data) =>
            {
                if (!data.Valid)
                    avgScore = -1;
                else {
                    foreach (var item in data.Scores) {
                        Debug.LogWarning("Score: " + item.value);
                        avgScore += item.value;
                    }
                    avgScore /= data.Scores.Length;
                }
                Debug.LogWarning("Average Score: " + avgScore);
                Debug.Log (data.PlayerScore);
                Debug.Log (data.PlayerScore.userID);
                //Debug.Log (data.PlayerScore.formattedValue);
            }
        );

        yield return new WaitForSeconds(2f);

        avgScore1 = avgScore;
    }
    /*
    public static long GetLeaderboardScores2() {

        string mStatus;
        IScore[] scores = new IScore[];
        long avgScore = 0;

        PlayGamesPlatform.Instance.LoadScores("CgkIx9zkzusWEAIQAQ",LeaderboardStart.PlayerCentered,10,LeaderboardCollection.Public,LeaderboardTimeSpan.AllTime,
            (data) =>
            {
                if (!data.Valid)
                    avgScore = -1;
                scores = data.Scores;
                Debug.LogWarning("Average Score: " + avgScore);
                Debug.Log (data.PlayerScore);
                Debug.Log (data.PlayerScore.userID);
                //Debug.Log (data.PlayerScore.formattedValue);
            }
        );

        if(avgScore == -1)
            return -1;

        foreach (var item in scores) {
            Debug.LogWarning("Score: " + item.value);
            avgScore += item.value;
        }
        avgScore /= scores.Length;

        return avgScore;
    }
    
    public static long GetLeaderboardScores3() {

        string mStatus;
        IScore[] scores = new IScore[];
        long avgScore = 0;

        PlayGamesPlatform.Instance.LoadScores("CgkIx9zkzusWEAIQBQ",LeaderboardStart.PlayerCentered,10,LeaderboardCollection.Public,LeaderboardTimeSpan.AllTime,
            (data) =>
            {
                if (!data.Valid)
                    avgScore = -1;
                scores = data.Scores;
                Debug.LogWarning("Average Score: " + avgScore);
                Debug.Log (data.PlayerScore);
                Debug.Log (data.PlayerScore.userID);
                //Debug.Log (data.PlayerScore.formattedValue);
            }
        );

        if(avgScore == -1)
            return -1;

        foreach (var item in scores) {
            Debug.LogWarning("Score: " + item.value);
            avgScore += item.value;
        }
        avgScore /= scores.Length;

        return avgScore;
    }*/
}
