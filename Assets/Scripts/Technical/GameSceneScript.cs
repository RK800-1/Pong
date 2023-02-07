using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is responsible for
/// the UI behaviour on the GameScene
/// </summary>
public class GameSceneScript : MonoBehaviour
{
    [SerializeField] private Text playerOneScore, playerTwoScore, winMessage;
    [SerializeField] private GameObject pauseMenu, pauseButton, ball, panelManager;

    SceneLoader sceneLoader;

	private void Start()
	{
        sceneLoader = panelManager.GetComponent<SceneLoader>();
	}

	protected IEnumerator WaitForUserToStart(bool _isGameOver)
    {
        ball.transform.position = new Vector3(0, 0, 0);

        Time.timeScale = 0;

        yield return new WaitUntil(() => Input.anyKeyDown);

        if (_isGameOver)
        {
            playerOneScore.text = "0";
            playerTwoScore.text = "0";
        }

        Time.timeScale = 1;
        this.StartGame();
        winMessage.gameObject.SetActive(false);
    }

    protected IEnumerator resumeDelay()
    {
        sceneLoader.resume(); //cratch
        winMessage.gameObject.SetActive(true);

        for (int i = 3; i >= 1; i--)
        {
            winMessage.text = "Match will be resumed in " + i + " seconds...";
            yield return new WaitForSecondsRealtime(1.0f);
        }

        winMessage.gameObject.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    protected void StartGame()
	{
        Rigidbody2D ballRB = ball.GetComponent<Rigidbody2D>();
        ballRB.velocity = Vector2.right * Ball.parmSpeed();
    }

    protected void GameOver()
    {
        winMessage.text = "Game Over! Press any key to restart the match.";
        StartCoroutine(WaitForUserToStart(true));
    }

    public void PrepareForStart()
    {
        playerOneScore.text = "0";
        playerTwoScore.text = "0";
        winMessage.gameObject.SetActive(true);
        winMessage.text = "Use up/down arrows to move if you play from pc \n" +
                          "Press any key to start";

        StartCoroutine(WaitForUserToStart(false));
    }

    public void PrintWinText(string _winner, int _pScore, bool _isEnd)
    {
        winMessage.gameObject.SetActive(true);
        bool isPlayerOne = (_winner == PlayerPrefs.GetString(SaveDataNames.PlayerName()));

        if(isPlayerOne)
		{
            playerOneScore.text = _pScore.ToString();
        }

        if(!isPlayerOne)
		{
            playerTwoScore.text = _pScore.ToString();

        }
        
        if(!_isEnd)
        {
            winMessage.text = "The goal is scored by " + _winner + '\n' + "Press any key to restart";
            StartCoroutine(WaitForUserToStart(false));
        }

        if(_isEnd)
        {
            this.GameOver();
        }
    }

    public void PauseButtonClick()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void resume()
	{
        StartCoroutine(resumeDelay());
	}
}
