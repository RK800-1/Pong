using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class is responsible for
/// behaviour when restart
/// </summary>
public class Restart : MonoBehaviour
{
    Vector2 ballPos, racketLeftPos, racketRightPos;
    TextUI textUI;
    Ball ballScript;
    GameObject racketLeft, racketRight, ball;

    void Start()
    {
        // Fucking crutch ->
        racketLeft = GameObject.FindWithTag("RacketLeft");
        racketRight = GameObject.FindWithTag("RacketRight");
        ball = GameObject.FindWithTag("Ball");
        // Fucking crutch <-
        textUI = FindObjectOfType<TextUI>();
        ballScript = FindObjectOfType<Ball>();
        racketLeftPos = racketLeft.transform.position;
        racketRightPos = racketRight.transform.position;
        ballPos = ball.transform.position;
    }

    public void ParmRestoreField(bool isEnd)
    {
        StartCoroutine(RestoreField(isEnd));
    }

    public IEnumerator RestoreField(bool isEnd) // restore pos & score
    {
        Time.timeScale = 0;

        // Fucking crutch ->
        racketLeft.transform.position = racketLeftPos;
        racketRight.transform.position = racketRightPos;
        ball.transform.position = ballPos;
        // Fucking crutch <-
        yield return new WaitUntil(() => Input.anyKeyDown);
        Time.timeScale = 1;
        textUI.WinMessage.SetActive(false);
        
        if(isEnd)
        {
            textUI.PlayerOneScore.text = textUI.PlayerTwoScore.text = "0";
            ballScript.PlayerOneScore = 0;
            ballScript.PlayerTwoScore = 0;
        }
    }
}
