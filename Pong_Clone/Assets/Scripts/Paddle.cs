using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    protected Vector2 _direction;
    public float _speed = 30.0f;

    void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        _rigidbody.transform.position = new Vector2(transform.position.x, 0f);
    }
}
