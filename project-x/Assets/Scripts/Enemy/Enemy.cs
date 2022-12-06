using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public bool IsVoiceNoticed { get; set; }
    protected bool IsEnemyOnSource { get; set; }
    protected float Speed { get; }  = 1f;
    protected Rigidbody2D Rigidbody2D;
    [HideInInspector] public Vector2 positionOfSound;
    protected bool IsMovingRight =true;
    protected bool IsMovingLeft = true;
    public int direction { get; set; }
    protected EnemyReactions _enemyReactions;
    public GameObject QuestMark;
    public GameObject ExclamationMark;
    protected Rigidbody2D _rigidbody2D;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        IsEnemyOnSource = false;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        _enemyReactions = new EnemyReactions();
        QuestMark = gameObject.transform.Find("Yellow").gameObject;
        ExclamationMark = gameObject.transform.Find("Red").gameObject;
    }
}
