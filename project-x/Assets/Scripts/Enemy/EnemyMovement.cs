using System;
using UnityEngine;

public class EnemyMovement : Enemy
{
    private bool _isGoingBack = false;
    private bool _isWorkingOnAlarm = false;
    private Vector2 _initialPosOfEnemy;
    private Vector2 _reachPos;
    private void Start()
    {
        _initialPosOfEnemy = Rigidbody2D.gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        if (IsVoiceNoticed && !IsEnemyOnAlarm && !_isWorkingOnAlarm && !_isGoingBack)
        {
            _reachPos = positionOfAlarm;
            Action<string, float> invoke = Invoke;
            invoke(nameof(Move),2);
        }
        if (_isWorkingOnAlarm)
        {
            _reachPos = _initialPosOfEnemy;
            Action<string, float> invoke = Invoke;
            invoke(nameof(BackToPosition),5);
            _isGoingBack = true;
        }
    }

    private void Update()
    {
        if (IsEnemyOnAlarm)
        {
            _isWorkingOnAlarm = true;
        }
        else
        {
            _isWorkingOnAlarm = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Alarm"))
        {
            IsEnemyOnAlarm = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Alarm"))
        {
            IsEnemyOnAlarm = false;
        }
    }

    private void Move()
    {
        var fixedSpeed = Speed * Time.fixedDeltaTime;
        if (_reachPos.x > transform.position.x && IsMovingRight)
        {
            IsMovingLeft = false;
            Rigidbody2D.MovePosition((Vector2)transform.position + Vector2.right * fixedSpeed);
        }
        else if (_reachPos.x < transform.position.x && IsMovingLeft)
        {
            IsMovingRight = false;
            Rigidbody2D.MovePosition((Vector2)transform.position + Vector2.left * fixedSpeed);
        }
    }

    private void BackToPosition()
    {
        IsVoiceNoticed = false;
        _isWorkingOnAlarm = false;
        IsMovingRight = true;
        IsMovingLeft = true;
        Move();
    }
}