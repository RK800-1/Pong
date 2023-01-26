using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is responsible for
/// settings panel
/// </summary>
public class Settings : MonoBehaviour
{
    [SerializeField] Text GTWText, difficultyText,
                          playerNamePlaceholder, playerNameText, reminder;
    string playerNameString;

    public void GetSettings() // print settings to UI (idk why it is bug here)
    {
        playerNameString = PlayerPrefs.GetString("PlayerName");
        playerNamePlaceholder.text = playerNameString;
        GTWText.text = PlayerPrefs.GetString("GoalToWin");
        difficultyText.text = PlayerPrefs.GetString("Difficulty");
        
        reminder.text = "";
    }

    public void SaveProgress()
    {
        playerNameString = playerNameText.text;

        PlayerPrefs.SetString("GoalToWin", GTWText.text);
        PlayerPrefs.SetString("Difficulty", difficultyText.text);
        PlayerPrefs.SetString("PlayerName", playerNameString);
        
        reminder.text = "Settings are saved!";
    }

    public bool IsEnd(int playerScore)
    {
        bool isEnd = false;
        string gtwString = PlayerPrefs.GetString("GoalToWin");

        if (playerScore == int.Parse(gtwString))
        {
            isEnd = true;
        }

        return isEnd;
    }

    public void ResetProgress()
    {
        PlayerPrefs.SetInt("GoalsScored", 0);
        PlayerPrefs.SetInt("GoalsMissed", 0);
        PlayerPrefs.SetInt("MatchesPlayed", 0);
        PlayerPrefs.SetString("PlayerName", "Player 1");
        PlayerPrefs.SetString("GoalToWin", "5");
        PlayerPrefs.SetString("Difficulty", "Easy");
        
        reminder.text = "Settings are reset to default!";
    }
}
