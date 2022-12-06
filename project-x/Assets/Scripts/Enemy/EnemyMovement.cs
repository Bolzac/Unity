using System;
using UnityEngine;

public class EnemyMovement : Enemy
{
    private Vector2 _reachPos;
    private Vector2 _initialPosOfEnemy;
    private bool _isGoingBack = false;
    private bool _isWorkingOnAlarm = false;
    private Collider2D[] _collider2Ds;
    
    private void Start()
    {
        _initialPosOfEnemy = Rigidbody2D.gameObject.transform.position;
    }

    private void Update()
    {
        if (IsEnemyOnSource)
        {
            IsVoiceNoticed = false;
            _isWorkingOnAlarm = true;
            direction = 0;
        }
        
        else
            _isWorkingOnAlarm = false;

        if (_isGoingBack)
        {
            _isWorkingOnAlarm = false;
            IsEnemyOnSource = false;
        }
        SetPositionOnDefault();
    }

    private void FixedUpdate()
    {
        if (IsVoiceNoticed && !IsEnemyOnSource && !_isWorkingOnAlarm && !_isGoingBack)
        {
            _reachPos = positionOfSound;
            Action<string, float> invoke = Invoke;
            invoke(nameof(Move), 2);
        }

        if (_isWorkingOnAlarm)
        {
            
            _reachPos = _initialPosOfEnemy;
            Action<string, float> invoke = Invoke;
            invoke(nameof(BackToPosition), 5);
        }
    }

    private void Move()
    {
        var fixedSpeed = Speed * Time.fixedDeltaTime;
        if (!Visual.IsSeen)
        {
            if (_reachPos.x > transform.position.x && IsMovingRight)
            {
                direction = 1;
                IsMovingLeft = false;
                Rigidbody2D.MovePosition((Vector2)transform.position + Vector2.right * fixedSpeed);
            }
            else if(!_isGoingBack && _reachPos.x < transform.position.x && !IsMovingLeft)
            {
                IsEnemyOnSource = true;
            }
            if (_reachPos.x < transform.position.x && IsMovingLeft)
            {
                direction = -1;
                IsMovingRight = false;
                Rigidbody2D.MovePosition((Vector2)transform.position + Vector2.left * fixedSpeed);
            }else if (!_isGoingBack && _reachPos.x > transform.position.x && !IsMovingRight)
            {
                IsEnemyOnSource = true;
            }
        }
    }

    private void BackToPosition()
    {
        _isGoingBack = true;
        IsVoiceNoticed = false;
        _isWorkingOnAlarm = false;
        IsMovingRight = true;
        IsMovingLeft = true;
        Move();
    }

    private void SetPositionOnDefault()
    {
        if (_isGoingBack)
        {
            if (IsMovingLeft)
            {
                if (transform.position.x <= _reachPos.x )
                {
                    _isGoingBack = false;
                    transform.position = _initialPosOfEnemy;
                    IsMovingLeft = true;
                    IsMovingRight = true;
                    QuestMark.SetActive(false);
                    direction = 0;
                }
            }else if (IsMovingRight)
            {
                if (transform.position.x >= _reachPos.x)
                {
                    _isGoingBack = false;
                    transform.position = _initialPosOfEnemy;
                    IsMovingLeft = true;
                    IsMovingRight = true;
                    QuestMark.SetActive(false);
                    direction = 0;
                }
            }
        }
    }
}