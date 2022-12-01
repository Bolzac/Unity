using System;
using UnityEngine;

public class CreateSound : Sound
{
    private RaycastHit2D[] hits;

    private void Awake()
    {
        hits = new RaycastHit2D[10];
        _enemyReactions = new EnemyReactions();
    }

    private void Update()
    {
        if (CanInteract && Input.GetKeyDown(KeyCode.E))
        {
            Create();
        }
    }
    // ReSharper disable Unity.PerformanceAnalysis
    private void Create()
    {
        var position = transform.position;
        Debug.DrawRay(position, transform.TransformDirection(Vector2.right) * Loudness, Color.white);
        var hitCount = Physics2D.RaycastNonAlloc(position, transform.TransformDirection(Vector2.right),hits,Loudness);
        for (var i = 0; i < hitCount; i++)
        {
            if (hits[i].collider.CompareTag("Enemy"))
            {
                var enemy = hits[i].collider.gameObject;
                _enemyReactions.SetQuestion(true,enemy.transform.Find("Yellow").gameObject);
                enemy.GetComponent<Enemy>().IsVoiceNoticed = true;
                enemy.GetComponent<Enemy>().positionOfAlarm = transform.position;
            }
        }
        //Nasıl aynı anda iki adet raycast çıkartırım?
        Debug.DrawRay(position, transform.TransformDirection(Vector2.left) * Loudness, Color.white);
        hitCount = Physics2D.RaycastNonAlloc(position, transform.TransformDirection(Vector2.left),hits,Loudness);
        for (var i = 0; i < hitCount; i++)
        {
            if (hits[i].collider.CompareTag("Enemy"))
            {
                var enemy = hits[i].collider.gameObject;
                _enemyReactions.SetQuestion(true,enemy.transform.Find("Yellow").gameObject);
                enemy.GetComponent<Enemy>().IsVoiceNoticed = true;
                enemy.GetComponent<Enemy>().positionOfAlarm = transform.position;
            }
        }
    }
}