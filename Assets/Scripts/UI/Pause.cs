using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This class is responsible for
/// the Pause menu
/// </summary>
public class Pause : MonoBehaviour
{
    TextUI textUI;
    GameObject pauseMenu;
    TapAudio tapAudio;

    void Start()
    {
        textUI = FindObjectOfType<TextUI>();
        pauseMenu = GameObject.FindWithTag("PauseMenu");
        tapAudio = GameObject.FindObjectOfType<TapAudio>();

        if(!textUI.isPause)
        {
            pauseMenu.SetActive(false);
        }
    }

    public void ResumeButton()
    {
        tapAudio.PlayTap();
        textUI.WinMessage.SetActive(true);
        textUI.parmDelay();
        pauseMenu.SetActive(false);
    }
    
    public void ExitButton()
    {
        SceneManager.LoadScene(0);
        pauseMenu.SetActive(false);
        tapAudio.PlayTap();
    }
}
