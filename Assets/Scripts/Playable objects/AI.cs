using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

/// <summary>
/// This class is responsible for
/// the AI behaviour
/// </summary>
public class AI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform racketAI;
    [SerializeField] private float speed = 10;
    [SerializeField] private bool isWait = false;
    Vector2 racketPos;
    public float randomFactor;
    string difficulty;

    Ball ball;

    private void Awake()
    {
        racketAI = GameObject.FindGameObjectWithTag("RacketRight").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        ball = FindObjectOfType<Ball>();
        difficulty = PlayerPrefs.GetString("Difficulty");
    }

    private void FixedUpdate()
    {
        AutoMove(randomFactor);
    }

    void AutoMove(float randomFactor) // AI movement
    {
        float x = transform.position.x;
        float getBallPos = ball.transform.position.y;
        float step = speed * Time.deltaTime * randomFactor;
        Vector2 targetPos = new Vector2(20, getBallPos);

        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);
    }

    public IEnumerator RandomRange() // AI delay just to make it easier/harder
    {
        isWait = true;

        switch(difficulty)
        {
            case "Easy":
                randomFactor = Random.Range(0.1f, 0.3f);
                break;
            case "Medium":
                randomFactor = Random.Range(0.4f, 0.6f);
                break;
            case "Hard":
                randomFactor = Random.Range(0.6f, 0.8f);
                break;
            default:
                randomFactor = Random.Range(0.45f, 0.95f);
                break;
        }

        yield return new WaitForSecondsRealtime(2f);
        isWait = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        string objName = col.gameObject.name;

        if(objName == "Ball")
        {
            StartCoroutine(RandomRange());
        }
    }
}
