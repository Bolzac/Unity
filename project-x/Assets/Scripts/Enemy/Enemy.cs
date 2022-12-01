using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public bool IsVoiceNoticed { get; set; }
    protected bool IsEnemyOnAlarm { get; set; }
    protected float Speed { get; }  = 1f;
    protected Rigidbody2D Rigidbody2D;
    [HideInInspector] public Vector2 positionOfAlarm;
    protected bool IsMovingRight =true;
    protected bool IsMovingLeft = true;
    public int direction { get; set; }
    private void Awake()
    {
        IsEnemyOnAlarm = false;
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
