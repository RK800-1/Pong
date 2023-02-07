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
    [SerializeField] private GameObject ball;
    [SerializeField] private float speed;

    public float randomFactor;


    private void Awake()
    {
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
        Vector2 targetPos = new Vector2(x, getBallPos);

        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);
    }

    public IEnumerator RandomRange() // AI delay just to make it easier/harder
    {
        switch(PlayerPrefs.GetInt(SaveDataNames.Difficulty()))
        {
            case 0:
                randomFactor = Random.Range(0.1f, 0.3f);
                break;
            case 1:
                randomFactor = Random.Range(0.4f, 0.6f);
                break;
            case 2:
                randomFactor = Random.Range(0.65f, 0.95f);
                break;
            default:
                randomFactor = Random.Range(0.45f, 0.5f);
                break;
        }

        yield return new WaitForSecondsRealtime(2f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        string objName = col.gameObject.name;

        if(objName == ball.name)
        {
            StartCoroutine(RandomRange());
        }
    }
}
