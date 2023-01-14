using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : DamageController
{
    private EnemyModel _enemyModel;

    private void Start()
    {
        _enemyModel = baseModel as EnemyModel;
        if(_enemyModel) _enemyModel.currentHealth = Random.Range(2, _enemyModel.enemyData.health);
    }

    private void OnDisable()
    {
        if(_enemyModel.killedByWeapon) LeftCoin();
        Destroy(gameObject);
    }
    
    private void LeftCoin()
    {
        StaticMethods.Instance.SpawnNewCard(_enemyModel.x, _enemyModel.y, _enemyModel.enemyData.reward);
    }
}