using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is responsible for
/// the saving/loading of the 
/// statistics variables
/// in Statistics panel
/// </summary>
public class StatsVars : MonoBehaviour
{
    [SerializeField] private Text PNText, goalsScoredText, goalsMissedText, matchesPlayedText;
    
    private static int matchesPlayed;

    public static void MatchCount()
    {
        matchesPlayed = PlayerPrefs.GetInt(SaveDataNames.MatchesPlayed());
        matchesPlayed++;
        PlayerPrefs.SetInt(SaveDataNames.MatchesPlayed(), matchesPlayed);
    }

    public static void SaveGoalStatistics(string _saveDataName, int _score)
    {
        int _goals = PlayerPrefs.GetInt(_saveDataName) + _score;
        PlayerPrefs.SetInt(_saveDataName, _goals);
        PlayerPrefs.Save();
    }
    
    public void GetGoals()
    {
        PNText.text = PlayerPrefs.GetString(SaveDataNames.PlayerName());
        goalsScoredText.text = PlayerPrefs.GetInt(SaveDataNames.GoalsScored()).ToString();
        goalsMissedText.text = PlayerPrefs.GetInt(SaveDataNames.GoalsMissed()).ToString();
        matchesPlayedText.text = PlayerPrefs.GetInt(SaveDataNames.MatchesPlayed()).ToString();
    }
}
