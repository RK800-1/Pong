using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanicsManager : MonoBehaviour
{
    [SerializeField] private GameObject racketLeft, racketRight, wallLeft, wallRight, ball;
	[SerializeField] private string winner;

	private int playerOneScore, playerTwoScore;
	private float racketLeftPos;

	GameSceneScript gameSceneScript;

	private void Start()
	{
		gameSceneScript = this.gameObject.GetComponent<GameSceneScript>();
		racketLeftPos = racketLeft.transform.position.x;
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
        ball.gameObject.GetComponent<Rigidbody2D>().velocity = dir * Ball.parmSpeed();
    }

	protected void WinAction(Collision2D col, string winner, Vector2 side, bool isEnd)
	{
		
		this.gameObject.GetComponent<Rigidbody2D>().velocity = side * Ball.parmSpeed();
	}

	protected bool IsGameOver(int playerScore)
	{
		var test = PlayerPrefs.GetInt(SaveDataNames.GoalToWin());

		if (playerScore >= PlayerPrefs.GetInt(SaveDataNames.GoalToWin()))
		{
			playerOneScore = playerTwoScore = 0;
			return true;
		}

		else
		{
			return false;
		}
	}
	
	protected void resetGameObjectsPos()
	{
		racketLeft.transform.position = new Vector2(racketLeftPos, 0);
		racketRight.transform.position = new Vector2(-racketLeftPos, 0);
		ball.transform.localPosition = new Vector3(0f, 0f, 0f);
	}

	public void resetSceneBeforeStart()
	{
		playerOneScore = playerTwoScore = 0;
		this.resetGameObjectsPos();
	}

    public void ballCollisionBehave(Collision2D _collideObject)
	{
        if(_collideObject.gameObject.name == racketLeft.name)
		{
            this.BallReaction(_collideObject, 1);
        }
        
		if(_collideObject.gameObject.name == racketRight.name)
		{
			this.BallReaction(_collideObject, -1);
		}

		if(_collideObject.gameObject.name == wallLeft.name)
		{
			playerTwoScore++;
			Vector2 right = Vector2.right;
			gameSceneScript.PrintWinText(winner, playerTwoScore, this.IsGameOver(playerTwoScore));
			this.resetGameObjectsPos();

			StatsVars.SaveGoalStatistics(SaveDataNames.GoalsMissed(), playerTwoScore);
		}

		if (_collideObject.gameObject.name == wallRight.name)
		{
			playerOneScore++;
			Vector2 left = Vector2.left;
			gameSceneScript.PrintWinText(PlayerPrefs.GetString(SaveDataNames.PlayerName()), playerOneScore, this.IsGameOver(playerOneScore));
			this.resetGameObjectsPos();

			StatsVars.SaveGoalStatistics(SaveDataNames.GoalsScored(), playerOneScore);
		}
    }

}
