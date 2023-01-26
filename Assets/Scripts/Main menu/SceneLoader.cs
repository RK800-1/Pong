using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is responsible for
/// the main menu
/// </summary>
public class SceneLoader : MonoBehaviour
{
    TapAudio tapAudioScript;
    StatsVars statsVars;
    Settings settingsScript;
    GameObject mmui, statistics, settings, aboutUs, returnToMenu;
    string[] objNames = { "MMUI", "Statistics", "Settings", "About", "Return" };

    private void Start()
    {
        tapAudioScript = GameObject.FindObjectOfType<TapAudio>();
        statsVars = FindObjectOfType<StatsVars>();
        settingsScript = FindObjectOfType<Settings>();
        mmui = GameObject.Find(objNames[0]);
        statistics = GameObject.Find(objNames[1]);
        settings = GameObject.Find(objNames[2]);
        aboutUs = GameObject.Find(objNames[3]);
        returnToMenu = GameObject.Find(objNames[4]);
    }

    public void PlayGame()
    {
        if (!PlayerPrefs.HasKey("MatchesPlayed")) //Check if the game has no saved data
        { 
            settingsScript.ResetProgress(); 
        }
        
        SceneManager.LoadScene(1);
        //tapAudioScript.PlayTap();
        Time.timeScale = 1;
        statsVars.MatchCount();
    }

    public void Statistics()
    {
        MenuLoader(statistics);
        ReturnToMenuActive();
        statsVars.GetGoals();
    }

    public void Settings()
    {
        MenuLoader(settings);
        ReturnToMenuActive();
        settingsScript.GetSettings();
    }

    public void AboutUs()
    {
        MenuLoader(aboutUs);
        ReturnToMenuActive();
    }

    void ReturnToMenuActive()
    {
        MenuLoader(returnToMenu);
        mmui.transform.localScale = new Vector3(0, 0, 0);
    }

    void MenuLoader(GameObject obj) // Get all child objects
    {
        obj.transform.localScale = new Vector3(1, 1, 1);
    }
}
