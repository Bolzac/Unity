using System;
using Unity.Mathematics;
using UnityEngine;
public class Enemy_Destroy : MonoBehaviour
{
    [SerializeField] GameObject _particle;
    private int _destroyCount = 0;
    private int _undestroyCount = 0;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Projectile_P"))
        {
            Instantiate(_particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            _destroyCount++;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Border"))
        {
            Destroy(gameObject);
            _undestroyCount++;
        }
    }

    private void Update()
    {
        if (_destroyCount + _undestroyCount == GameManager.EnemyCount)
        {
            GameManager.EnemyCount = _undestroyCount;
        }
    }
}