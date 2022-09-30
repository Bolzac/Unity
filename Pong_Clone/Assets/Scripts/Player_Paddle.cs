using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Paddle : Paddle
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
        }
        else
        {
            _direction = Vector2.zero;
        }
    }
    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0)
        {
            _rigidbody.AddForce(_direction * _speed);
        }
    }
}
