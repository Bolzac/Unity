using System;
using UnityEngine;

public class EnemyMovement : Enemy
{
    private Vector2 _reachPos;
    private Vector2 _initialPosOfEnemy;
    private bool _isGoingBack;
    private bool _isWorkingOnAlarm;
    private float y;
    
    private void Start()
    {
        y = gameObject.transform.position.y;
        _initialPosOfEnemy = Rigidbody2D.gameObject.transform.position;
    }

    private void Update()
    {
        if (IsEnemyOnSource)
        {
            _isWorkingOnAlarm = true;
            direction = 0;
        }
        else
            _isWorkingOnAlarm = false;
        ManageMove();
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

    private void ManageMove()
    {
        if (positionOfSound.x >= transform.position.x)
        {
            if (transform.position.x <= _reachPos.x && _isGoingBack)
            {
                _isGoingBack = false;
                transform.position = _initialPosOfEnemy;
                IsMovingLeft = true;
                IsMovingRight = true;
                direction = 0;
                _enemyReactions.SetQuestion(false,QuestMark);
            }
        }else if (positionOfSound.x <= transform.position.x)
        {
            if (transform.position.x >= _reachPos.x && _isGoingBack)
            {
                _isGoingBack = false;
                transform.position = _initialPosOfEnemy;
                IsMovingLeft = true;
                IsMovingRight = true;
                direction = 0;
                _enemyReactions.SetQuestion(false,QuestMark);
            }
        }
    }
}