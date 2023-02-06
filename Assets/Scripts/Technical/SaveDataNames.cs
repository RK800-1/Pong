using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataNames : MonoBehaviour
{
    private static string playerName = "PlayerName";
    private static string goalsScored = "GoalsScored";
    private static string goalsMissed = "GoalsMissed";
    private static string matchesplayed = "MatchesPlayed";
    private static string goalToWin = "GoalToWin";
    private static string difficulty = "Difficulty";
    private static string settingsAreChanged = "SettingsAreChanged";

    public static string PlayerName()
	{
        return playerName;
	}

    public static string GoalsScored()
    {
        return goalsScored;
    }

    public static string GoalsMissed()
    {
        return goalsMissed;
    }

    public static string MatchesPlayed()
    {
        return matchesplayed;
    }

    public static string GoalToWin()
    {
        return goalToWin;
    }

    public static string Difficulty()
    {
        return difficulty;
    }

    public static string SettingsAreChanged()
    {
        return settingsAreChanged;
    }
}
