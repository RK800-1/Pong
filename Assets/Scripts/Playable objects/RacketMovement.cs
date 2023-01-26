using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for
/// the movement of the rackets
/// IDK how to make normal control
/// for touch
/// </summary>
public class RacketMovement : MonoBehaviour
{
    Rigidbody2D racketControl;
    Camera camera;
    public float speed = 2;
    public string axis = "Vertical";

    private void Awake()
    {
        camera = Camera.main;
    }

    void Update()
    {
        float v = Input.GetAxis(axis);
        racketControl = GetComponent<Rigidbody2D>();
        racketControl.velocity = new Vector2(0, v) * speed;
        //Debug.Log(racketControl.velocity);
        //Debug.Log(v);

        //racketControl = GetComponent<Rigidbody2D>();
        //Vector3 v;

        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    v = camera.ScreenToWorldPoint(touch.position);
        //    switch (touch.phase)
        //    {
        //        case TouchPhase.Began:
        //            break;

        //        case TouchPhase.Moved:
        //            racketControl.position = new Vector2(-20, v.y);
        //            break;

        //        default:
        //            break;

        //    }
        //}
    }
}
