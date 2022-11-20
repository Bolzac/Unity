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
    private void Spawn_Enemy()
    {
        _count++;
        Instantiate(enemy, enemy.transform.position, quaternion.identity);
        if (_count < GameManager.EnemyCount)
        {
            Invoke(nameof(Spawn_Enemy),rate);
        }
    }
    private void Start()
    {
        Spawn_Enemy();
    }

    private void Update()
    {
        if (GameManager.EnemyCount <= _count && GameManager.EnemyCount != 0)
        {
            _count = 0;
            Spawn_Enemy();
        }else if (GameManager.EnemyCount == 0)
        { 
            FindObjectOfType<GameManager>().NextWave();
        }
    }
}
