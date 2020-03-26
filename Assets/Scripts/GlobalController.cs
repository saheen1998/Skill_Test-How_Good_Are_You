using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalController
{
    public static string currUser = "GUEST";
    public static int fromTest;
    public static int newScore = 0;
    public static int scoreTest1 = 0;
    public static int scoreTest2 = 0;
    public static int scoreTest3 = 0;
    public static int highScoreTest1 = 0;
    public static int highScoreTest2 = 0;
    public static int highScoreTest3 = 0;
    public static bool completedTest1 = false;
    public static bool completedTest2 = false;
    public static bool completedTest3 = false;
    public static bool playTut1 = true;
    public static bool playTut2 = true;
    public static bool playTut3 = true;

    public static void AddNewScoreTest1(int score) {
        completedTest1 = true;
        scoreTest1 = score;
        if(score > highScoreTest1)
            highScoreTest1 = score;
        if(currUser != "GUEST")
            PlayGamesController.PostToLeaderboardTest1((long)score);

        for(int i = 1; i <= 10; ++i) {
            string keyStr = "test1Score" + i;
            if(!PlayerPrefs.HasKey(keyStr)) {
                PlayerPrefs.SetInt(keyStr, score);
                return;
            }
        }

        for(int i = 1; i < 10; ++i) {
            string keyStr1 = "test1Score" + i;
            string keyStr2 = "test1Score" + (i + 1);
            PlayerPrefs.SetInt(keyStr1, PlayerPrefs.GetInt(keyStr2));
        }
        PlayerPrefs.SetInt("test1Score10", score);
    }

    public static void AddNewScoreTest2(int score) {
        completedTest2 = true;
        scoreTest2 = score;
        if(score > highScoreTest2)
            highScoreTest2 = score;
        if(currUser != "GUEST")
            PlayGamesController.PostToLeaderboardTest2((long)score);

        for(int i = 1; i <= 10; ++i) {
            string keyStr = "test2Score" + i;
            if(!PlayerPrefs.HasKey(keyStr)) {
                PlayerPrefs.SetInt(keyStr, score);
                return;
            }
        }

        for(int i = 1; i < 10; ++i) {
            string keyStr1 = "test2Score" + i;
            string keyStr2 = "test2Score" + (i + 1);
            PlayerPrefs.SetInt(keyStr1, PlayerPrefs.GetInt(keyStr2));
        }
        PlayerPrefs.SetInt("test2Score10", score);
    }

    public static void AddNewScoreTest3(int score) {
        completedTest3 = true;
        scoreTest3 = score;
        if(score > highScoreTest3)
            highScoreTest3 = score;
        if(currUser != "GUEST")
            PlayGamesController.PostToLeaderboardTest3((long)score);

        for(int i = 1; i <= 10; ++i) {
            string keyStr = "test3Score" + i;
            if(!PlayerPrefs.HasKey(keyStr)) {
                PlayerPrefs.SetInt(keyStr, score);
                return;
            }
        }

        for(int i = 1; i < 10; ++i) {
            string keyStr1 = "test3Score" + i;
            string keyStr2 = "test3Score" + (i + 1);
            PlayerPrefs.SetInt(keyStr1, PlayerPrefs.GetInt(keyStr2));
        }
        PlayerPrefs.SetInt("test3Score10", score);
    }

    public static List<int> GetScores(int testNo) {

        List<int> ret = new List<int>();
        for(int i = 1; i <= 10; i++) {
            string keyStr = "test" + testNo + "Score" + i;
            if(PlayerPrefs.HasKey(keyStr)) {
                ret.Add(PlayerPrefs.GetInt(keyStr));
            }
        }
        return ret;
    }

    public static bool CheckIfFirstTimeRun() {
        if(PlayerPrefs.HasKey("firstRun")) {
            if(PlayerPrefs.GetInt("firstRun") == 0)
                return false;
            if(PlayerPrefs.GetInt("firstRun") == 1)
                return true;
        }
        return true;
    }

    public static void SetFirstTimeRun(bool cond) {
        int val = (cond == true) ? 1 : 0;
        PlayerPrefs.SetInt("firstRun", val);
    }
}
