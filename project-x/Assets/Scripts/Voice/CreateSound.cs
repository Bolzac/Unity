using System;
using UnityEngine;

public class CreateSound
{
    private readonly RaycastHit2D[] hits = new RaycastHit2D[5];
    private EnemyReactions _enemyReactions = new EnemyReactions();
    private EnemyMovement _enemyMovement;

    // ReSharper disable Unity.PerformanceAnalysis
    public void Create(GameObject _gameObject, float Loudness)
    {
        var x = Loudness;
        var position = _gameObject.transform.position;
        Debug.DrawRay(position, _gameObject.transform.TransformDirection(Vector2.right) * Loudness, Color.white);
        var hitCount = Physics2D.RaycastNonAlloc(position, _gameObject.transform.TransformDirection(Vector2.right),hits,x);
        for (var i = 0; i < hitCount; i++)
        {
            if (hits[i].collider.CompareTag("Enemy"))
            {
                var enemy = hits[i].collider.gameObject;
                _enemyReactions.SetQuestion(true,enemy.transform.Find("Yellow").gameObject);
                enemy.GetComponent<Enemy>().IsVoiceNoticed = true;
                enemy.GetComponent<Enemy>().positionOfSound = _gameObject.transform.position;
            }
        }
        //Nasıl aynı anda iki adet raycast çıkartırım?
        Debug.DrawRay(position, _gameObject.transform.TransformDirection(Vector2.left) * Loudness, Color.white);
        hitCount = Physics2D.RaycastNonAlloc(position, _gameObject.transform.TransformDirection(Vector2.left),hits,x);
        for (var i = 0; i < hitCount; i++)
        {
            if (hits[i].collider.CompareTag("Enemy"))
            {
                var enemy = hits[i].collider.gameObject;
                _enemyReactions.SetQuestion(true,enemy.transform.Find("Yellow").gameObject);
                enemy.GetComponent<Enemy>().IsVoiceNoticed = true;
                enemy.GetComponent<Enemy>().positionOfSound = _gameObject.transform.position;
            }
        }
    }
}