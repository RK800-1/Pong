using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is responsible for
/// settings panel
/// </summary>
public class Settings : MonoBehaviour
{
    [SerializeField] private Text GTWText, difficultyText, reminder;
    [SerializeField] private InputField playerNameInputField;

    public void GetSettings()
    {
        if(!PlayerPrefs.HasKey(SaveDataNames.SettingsAreChanged()))
		{
            this.ResetProgress();
		}

        playerNameInputField.text = PlayerPrefs.GetString(SaveDataNames.PlayerName());
        GTWText.text = PlayerPrefs.GetInt(SaveDataNames.GoalToWin()).ToString();
        difficultyText.text = PlayerPrefs.GetString(SaveDataNames.Difficulty());
        
        reminder.text = "";
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt(SaveDataNames.GoalToWin(), int.Parse(GTWText.text));
        PlayerPrefs.SetString(SaveDataNames.Difficulty(), difficultyText.text);
        PlayerPrefs.SetString(SaveDataNames.PlayerName(), playerNameInputField.text);
        
        reminder.text = "Settings are saved!";
    }

    public void ResetProgress()
    {
        PlayerPrefs.SetInt(SaveDataNames.GoalsScored(), 0);
        PlayerPrefs.SetInt(SaveDataNames.GoalsMissed(), 0);
        PlayerPrefs.SetInt(SaveDataNames.MatchesPlayed(), 0);
        PlayerPrefs.SetInt(SaveDataNames.GoalToWin(), 5);
        PlayerPrefs.SetInt(SaveDataNames.SettingsAreChanged(), 1);
        PlayerPrefs.SetString(SaveDataNames.PlayerName(), "Player 1");
        PlayerPrefs.SetString(SaveDataNames.Difficulty(), "Easy");
        
        reminder.text = "Settings are reset to default!";
    }

    public bool IsEnd(int playerScore)
    {
        bool isEnd = false;
        int gtwString = PlayerPrefs.GetInt(SaveDataNames.GoalToWin());

        if (playerScore == gtwString)
        {
            isEnd = true;
        }

        return isEnd;
    }
}
