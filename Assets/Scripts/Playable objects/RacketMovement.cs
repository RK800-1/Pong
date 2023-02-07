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

    public float speed = 2;
    public string axis = "Vertical";

    private void Awake()
    {
        racketControl = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float v = Input.GetAxis(axis);

        if(v != 0)
        {
            this.racketVelocityUpdate(v);
        }
        
  //      else if(Input.touchCount > 0)
		//{
  //          Touch touch = Input.GetTouch(0);
            
  //          if(touch.phase == TouchPhase.Began)
		//	{
  //              this.racketVelocityUpdate(touch.position.y);
  //          }
		//}
        
    }

    protected void racketVelocityUpdate(float _yPos)
    {
        racketControl.velocity = new Vector2(0, _yPos) * speed;
    }
}
