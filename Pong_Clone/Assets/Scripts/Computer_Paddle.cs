using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer_Paddle : Paddle
{
    public Ball ball;

    private void Update()
    {
        if (ball.rigidbody.velocity.x > 0.5f)
        {
            if (ball.transform.position.y > transform.position.y)
            {
                _direction = Vector2.up;
                _rigidbody.AddForce(_direction * _speed);
            }
            else if (ball.transform.position.y < transform.position.y)
            {
                _direction = Vector2.down;
                _rigidbody.AddForce(_direction * _speed);
            }
        }
        else
        {
            if (transform.position.y > 0)
            {
                _direction = Vector2.down;
                _rigidbody.AddForce(_direction * _speed);
            }
            else
            {
                _direction = Vector2.up;
                _rigidbody.AddForce(_direction * _speed);
            }
        }
    }
}