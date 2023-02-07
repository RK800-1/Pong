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
    [SerializeField] private Text reminder;
    [SerializeField] private Dropdown goalsToWin, difficulty;
    [SerializeField] private InputField playerNameInputField;

    public void GetSettings()
    {
        if(!PlayerPrefs.HasKey(SaveDataNames.SettingsAreChanged()))
		{
            this.ResetProgress();
		}

        playerNameInputField.text = PlayerPrefs.GetString(SaveDataNames.PlayerName());
        goalsToWin.value = PlayerPrefs.GetInt(SaveDataNames.GoalToWinIndex());
        difficulty.value = PlayerPrefs.GetInt(SaveDataNames.Difficulty());
        
        reminder.text = "";
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt(SaveDataNames.GoalToWin(), int.Parse(goalsToWin.options[goalsToWin.value].text));
        PlayerPrefs.SetInt(SaveDataNames.GoalToWinIndex(), goalsToWin.value);
        PlayerPrefs.SetInt(SaveDataNames.Difficulty(), difficulty.value);
        PlayerPrefs.SetString(SaveDataNames.PlayerName(), playerNameInputField.text);
        PlayerPrefs.Save();
        
        reminder.text = "Settings are saved!";
    }

    public void ResetProgress()
    {
        PlayerPrefs.SetInt(SaveDataNames.GoalsScored(), 0);
        PlayerPrefs.SetInt(SaveDataNames.GoalsMissed(), 0);
        PlayerPrefs.SetInt(SaveDataNames.MatchesPlayed(), 0);
        PlayerPrefs.SetInt(SaveDataNames.GoalToWinIndex(), 0);
        PlayerPrefs.SetInt(SaveDataNames.GoalToWin(), 5);
        PlayerPrefs.SetInt(SaveDataNames.SettingsAreChanged(), 1);
        PlayerPrefs.SetInt(SaveDataNames.Difficulty(), 0);
        PlayerPrefs.SetString(SaveDataNames.PlayerName(), "Player 1");
        
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
