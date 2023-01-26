using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private Text PNText, goalsScoredText, 
                                  goalsMissedText, matchesPlayedText;
    int goalsScored, goalsMissed, matchesPlayed;

    public void MatchCount()
    {
        matchesPlayed = PlayerPrefs.GetInt("MatchesPlayed");
        matchesPlayed++;
        PlayerPrefs.SetInt("MatchesPlayed", matchesPlayed);
    }

    public void GoalVals(string side)
    {
        goalsScored = PlayerPrefs.GetInt("GoalsScored");
        goalsMissed = PlayerPrefs.GetInt("GoalsMissed");
        matchesPlayed = PlayerPrefs.GetInt("MatchesPlayed");

        switch (side)
        {
            case "Wall_Left":
                ++goalsMissed;
                PlayerPrefs.SetInt("GoalsMissed", goalsMissed);
                PlayerPrefs.Save();
                break;
            case "Wall_Right":
                ++goalsScored;
                PlayerPrefs.SetInt("GoalsScored", goalsScored);
                PlayerPrefs.Save();
                break;
            default: break;
        }
    }
    
    public void GetGoals()
    {
        PNText.text = PlayerPrefs.GetString("PlayerName");
        goalsScoredText.text = PlayerPrefs.GetInt("GoalsScored").ToString();
        goalsMissedText.text = PlayerPrefs.GetInt("GoalsMissed").ToString();
        matchesPlayedText.text = PlayerPrefs.GetInt("MatchesPlayed").ToString();
    }
}
