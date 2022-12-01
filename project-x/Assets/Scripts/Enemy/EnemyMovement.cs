using System;
using UnityEngine;

public class EnemyMovement : Enemy
{
    private Vector2 _initialPosOfEnemy;
    private bool _isGoingBack;
    private bool _isWorkingOnAlarm;
    private Vector2 _reachPos;

    private void Start()
    {
        _initialPosOfEnemy = Rigidbody2D.gameObject.transform.position;
    }

    private void Update()
    {
        if (IsEnemyOnAlarm)
        {
            _isWorkingOnAlarm = true;
            direction = 0;
        }
        else
            _isWorkingOnAlarm = false;
        
        Debug.Log(Player.IsVisible);
    }

    private void FixedUpdate()
    {
        if (IsVoiceNoticed && !IsEnemyOnAlarm && !_isWorkingOnAlarm && !_isGoingBack)
        {
            _reachPos = positionOfAlarm;
            Action<string, float> invoke = Invoke;
            invoke(nameof(Move), 2);
        }

        if (_isWorkingOnAlarm)
        {
            
            _reachPos = _initialPosOfEnemy;
            Action<string, float> invoke = Invoke;
            invoke(nameof(BackToPosition), 5);
        }
        ManageMove();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Alarm")) IsEnemyOnAlarm = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Alarm")) IsEnemyOnAlarm = false;
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
            else if (_reachPos.x < transform.position.x && IsMovingLeft && !Visual.IsSeen)
            {
                direction = -1;
                IsMovingRight = false;
                Rigidbody2D.MovePosition((Vector2)transform.position + Vector2.left * fixedSpeed);
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
        if (positionOfAlarm.x >= transform.position.x)
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
        }else if (positionOfAlarm.x <= transform.position.x)
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