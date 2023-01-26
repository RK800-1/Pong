using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for
/// the ball behaviour and its
/// affection to the score
/// </summary>
public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int playerOneScore, playerTwoScore;
    private string winner = "";

    TextUI textUI;
    Restart restart;
    BallHitAudio ballHitaudio;
    StatsVars statsVars;

    public int PlayerOneScore
    {
        get
        {
            return playerOneScore = 0;
        }

        set
        {
            playerOneScore = PlayerOneScore;
        }
    }

    public int PlayerTwoScore
    {
        get
        {
            return playerTwoScore = 0;
        }

        set
        {
            playerTwoScore = PlayerTwoScore;
        }
    }

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        textUI = FindObjectOfType<TextUI>();
        restart = FindObjectOfType<Restart>();
        ballHitaudio = FindObjectOfType<BallHitAudio>();
        statsVars = FindObjectOfType<StatsVars>();
    }

    protected float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    protected void BallReaction(Collision2D col, int x)
    {
        float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);
        Vector2 dir = new Vector2(x, y).normalized;
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    protected void WinAction(Collision2D col, string winner, Vector2 side, bool isEnd)
    {
        textUI.PrintTextToUI(winner, playerOneScore, playerTwoScore, isEnd);
        restart.ParmRestoreField(false);
        GetComponent<Rigidbody2D>().velocity = side * speed;
    }

    bool IsGameOver(int playerScore)
    {
        bool IsGameOver;

        string gtwString = PlayerPrefs.GetString("GoalToWin");

        if (playerScore == int.Parse(gtwString))
        {
            IsGameOver = true;
        }

        else
        {
            IsGameOver = false;
        }

        return IsGameOver;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string objName = col.gameObject.name;
        bool isGameOver;
        
        ballHitaudio.PlayBallHit();

        switch (objName)
        {
            case "Racket_Left":
                this.BallReaction(col, 1);
                break;
            case "Racket_Right":
                this.BallReaction(col, -1);
                break;
            case "Wall_Left":
                winner = "Player 2";
                ++playerTwoScore;
                statsVars.GoalVals(objName);
                Vector2 right = Vector2.right;
                isGameOver = this.IsGameOver(playerTwoScore);
                this.WinAction(col, winner, right, isGameOver);
                break;
            case "Wall_Right":
                winner = PlayerPrefs.GetString("PlayerName");
                ++playerOneScore;
                statsVars.GoalVals(objName);
                Vector2 left = Vector2.left;
                isGameOver = this.IsGameOver(playerOneScore);
                this.WinAction(col, winner, left, isGameOver);
                break;

            default: break;

        }
    }
}
