using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _moveSpeed = 1.5f;
    protected Rigidbody2D Rb2;
    protected Vector2 CurrentPosition;
    protected float Movespeed
    {
        get => _moveSpeed;
        set => _moveSpeed = value;
    }
    private bool _isRight = true;
    private Vector2 _direction;
    protected Vector2 Direction
    {
        get => _direction;
        set => _direction = value;
        }
    protected bool IsVisible = true;
    protected bool CanHide = false;
    protected static bool CanInteract = false;
    public bool isSeen = false;
    private void Update()
    {
        DetectInput();
        DetectDirection();
    }

    private void DetectInput()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
    }

    private void DetectDirection()
    {
        if (_direction.x >0)
        {
            transform.localRotation = new Quaternion(0, 0, 0,0);
        }else if (_direction.x < 0)
        {
            transform.localRotation = new Quaternion(0, 180, 0,0);
        }
    }
}