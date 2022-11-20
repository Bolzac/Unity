using System;
using Unity.Mathematics;
using UnityEngine;
public class Enemy_Destroy : MonoBehaviour
{
    [SerializeField] GameObject _particle;
    private Spawner _spawner;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Projectile_P"))
        {
            Instantiate(_particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            _spawner.destroyCount++;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Border"))
        {
            Destroy(gameObject);
            _spawner.undestroyCount++;
        }
    }

    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
    }

    private void Update()
    {
        if (_spawner.destroyCount + _spawner.undestroyCount == GameManager.EnemyCount)
        {
            GameManager.EnemyCount = _spawner.undestroyCount;
        }
    }
}