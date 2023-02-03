using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyModel : MonoBehaviour
{
    public int health;
    
    public float maxTimeToFire;
    
    public float timeCounter;

    public bool isSeenPlayer;
    public bool isTimerStart;

    #region View

    public float radius;
    public float maxAngle;
    public float perAngle;
    public int catchCounter;

    public Vector2 currentPosition;
    public Transform eye;
    
    public RaycastHit2D[] Results;
    
    #endregion
    #region Events

    public UnityEvent<bool> onCatch;

    #endregion

    private void Update()
    {
        currentPosition = transform.position;
    }
}