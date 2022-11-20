using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float rate = 1;
    [SerializeField] private GameObject enemy;
    private int _count = 0;
    public int destroyCount = 0;
    public int dc = 0;
    public int undestroyCount = 0;
    private GameManager _gameManager;
    private void Spawn_Enemy()
    {
        _count++;
        Instantiate(enemy, enemy.transform.position, quaternion.identity);
        if (_count < GameManager.EnemyCount)
        {
            Invoke(nameof(Spawn_Enemy),rate);
        }
    }

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        Spawn_Enemy();
    }

    private void Update()
    {
        if (GameManager.EnemyCount <= _count && GameManager.EnemyCount != 0 && destroyCount + undestroyCount == GameManager.EnemyCount)
        {
            GameManager.EnemyCount = undestroyCount;
            _count = 0;
            destroyCount = 0;
            undestroyCount = 0;
            Spawn_Enemy();
        }else if (GameManager.EnemyCount == 0)
        { 
            _gameManager.NextWave();
        }
    }
}
