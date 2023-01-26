using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is responsible for
/// the UI behaviour on the GameScene
/// </summary>
public class TextUI : MonoBehaviour
{
    [SerializeField] private Text playerOneScore, playerTwoScore, winText;
    [SerializeField] private GameObject winMessage, pauseMenu, pauseButton;
    private PrepareForStart prepareForStart;
    private Restart restart;
    private PauseAudio pauseAudio;
    
    public bool isPause = false;

    public GameObject WinMessage
    {
        get 
        {
            return winMessage;
        }

        set
        {
            winMessage = WinMessage;
        }
    }

    public Text WinText
    {
        get
        {
            return winText;
        }

        set
        {
            winText = WinText;
        }
    }

    public Text PlayerOneScore
    {
        get 
        {
            return playerOneScore;
        }

        set
        {
            playerOneScore = PlayerOneScore;
        }
    }

    public Text PlayerTwoScore
    {
        get
        {
            return playerTwoScore;
        }

        set
        {
            playerTwoScore = PlayerTwoScore;
        }
    }

    public void Start()
    {
        winMessage = GameObject.FindWithTag("WinMessage");
        pauseMenu = GameObject.FindWithTag("PauseMenu");
        pauseButton = GameObject.FindWithTag("PauseButton");
        restart = FindObjectOfType<Restart>();
        pauseAudio = GameObject.FindObjectOfType<PauseAudio>();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private void Awake()
    {
        winMessage.SetActive(true);
        prepareForStart = GameObject.FindObjectOfType<PrepareForStart>();
        prepareForStart.PrepareStart();
    }

    public void PrintTextToUI(string winner, int pOScore, int pTScore, bool isEnd)
    {
        winMessage.SetActive(true);
        bool isPlayerOne = winner == PlayerPrefs.GetString("PlayerName");

        switch (isPlayerOne) 
        {
            case true:
                playerOneScore.text = pOScore.ToString("0");
                break;
            case false:
                playerTwoScore.text = pTScore.ToString("0");
                break;
            default: 
        }

        if(!isEnd)
        {
            winText.text = "The goal is scored by " + winner + '\n' + "Press any key to restart";
        }

        if(isEnd)
        {
            GameOver();
        }
    }

    public void PauseButtonClick()
    {
        pauseAudio.PlayTap();
        Time.timeScale = 0;
        isPause = true;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    IEnumerator Delay() // pause before resume
    {
        for (int i = 3; i >= 1; i--)
        {
            winText.text = "Match will be resumed in " + i + " seconds...";
            yield return new WaitForSecondsRealtime(1.0f);
        }

        winText.text = ""; // fucking cratch wtf it was OK a version before
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    void GameOver()
    {
        winText.text = "Game Over! Press any key to restart the match.";
        restart.ParmRestoreField(true);
        
    }

    public void parmDelay() //just to implement encapsulation
    {
        StartCoroutine(this.Delay());
    }

}
