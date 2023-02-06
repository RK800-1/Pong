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
    [SerializeField] GameObject gameSceneManager, ballHitSound;
    
    BallHitAudio ballHitAudio;
    GameMechanicsManager gameMechanicsManager;
    
    private static float speed = 40f;


    private void Start()
	{
        gameMechanicsManager = gameSceneManager.GetComponent<GameMechanicsManager>();
        ballHitAudio = ballHitSound.GetComponent<BallHitAudio>();

    }

	private void OnCollisionEnter2D(Collision2D col)
    {
        ballHitAudio.PlayBallHit();
        gameMechanicsManager.ballCollisionBehave(col);
    }

    public static float parmSpeed()
    {
        return speed;
    }
}
